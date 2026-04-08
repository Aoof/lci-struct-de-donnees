import argparse
import re
from pathlib import Path

import matplotlib.pyplot as plt
import numpy as np
import pandas as pd


def parse_numeric_with_unit(value: str) -> float:
    text = str(value).strip().replace(",", "").replace("_", "")
    match = re.match(r"^([0-9]+(?:\.[0-9]+)?)\s*([a-zA-Z\u03bc]+)?$", text)
    if not match:
        raise ValueError(f"Cannot parse numeric value: {value}")

    number = float(match.group(1))
    unit = (match.group(2) or "").lower()

    if unit in {"ns"}:
        return number
    if unit in {"us", "μs"}:
        return number * 1_000.0
    if unit in {"ms"}:
        return number * 1_000_000.0
    if unit in {"s"}:
        return number * 1_000_000_000.0

    raise ValueError(f"Unsupported unit '{unit}' for value: {value}")


def parse_size_kb(value: str) -> float:
    text = str(value).strip().replace(",", "").replace("_", "")
    match = re.match(r"^([0-9]+(?:\.[0-9]+)?)\s*([kmg]?b)?$", text, re.IGNORECASE)
    if not match:
        raise ValueError(f"Cannot parse allocated size: {value}")

    number = float(match.group(1))
    unit = (match.group(2) or "KB").lower()

    if unit == "kb":
        return number
    if unit == "mb":
        return number * 1024.0
    if unit == "gb":
        return number * 1024.0 * 1024.0
    if unit == "b":
        return number / 1024.0

    raise ValueError(f"Unsupported memory unit '{unit}' for value: {value}")


def plot_metric(
    df: pd.DataFrame,
    metric_col: str,
    y_label: str,
    title: str,
    output_path: Path,
    x_log_scale: bool,
    y_log_scale: bool,
) -> None:
    plt.figure(figsize=(11, 7))
    methods = sorted(df["Method"].unique())
    cmap = plt.get_cmap("tab10")
    color_by_method = {method: cmap(i % 10) for i, method in enumerate(methods)}

    for method, group in df.groupby("Method"):
        ordered = group.sort_values("N")
        x = ordered["N"].to_numpy(dtype=float)
        y = ordered[metric_col].to_numpy(dtype=float)
        color = color_by_method[method]

        if len(x) >= 3 and np.all(y > 0):
            log_x = np.log(x)
            log_y = np.log(y)
            log_x_smooth = np.linspace(log_x.min(), log_x.max(), 220)
            log_y_smooth = pchip_evaluate(log_x, log_y, log_x_smooth)

            x_smooth = np.exp(log_x_smooth)
            y_smooth = np.exp(log_y_smooth)

            plt.plot(
                x,
                y,
                marker="o",
                linestyle="None",
                markersize=5,
                color=color,
                label=f"{method} observed",
            )
            plt.plot(x_smooth, y_smooth, linewidth=2, color=color, alpha=0.85, label=f"{method} smoothed")
        else:
            plt.plot(x, y, marker="o", linewidth=2, color=color, label=method)

    if x_log_scale:
        plt.xscale("log")
    if y_log_scale:
        plt.yscale("log")
    plt.xlabel("N")
    plt.ylabel(y_label)
    plt.title(title)
    plt.grid(True, which="both", linestyle="--", linewidth=0.5, alpha=0.5)
    plt.legend(loc="best", fontsize=8)
    plt.tight_layout()
    plt.savefig(output_path, dpi=180)
    plt.close()


def pchip_slopes(x: np.ndarray, y: np.ndarray) -> np.ndarray:
    n = len(x)
    m = np.zeros(n)

    if n == 2:
        slope = (y[1] - y[0]) / (x[1] - x[0])
        m[0] = slope
        m[1] = slope
        return m

    h = np.diff(x)
    delta = np.diff(y) / h

    for k in range(1, n - 1):
        if delta[k - 1] * delta[k] <= 0:
            m[k] = 0.0
        else:
            w1 = 2 * h[k] + h[k - 1]
            w2 = h[k] + 2 * h[k - 1]
            m[k] = (w1 + w2) / (w1 / delta[k - 1] + w2 / delta[k])

    m0 = ((2 * h[0] + h[1]) * delta[0] - h[0] * delta[1]) / (h[0] + h[1])
    if np.sign(m0) != np.sign(delta[0]):
        m0 = 0.0
    elif abs(m0) > 3 * abs(delta[0]):
        m0 = 3 * delta[0]
    m[0] = m0

    mn = ((2 * h[-1] + h[-2]) * delta[-1] - h[-1] * delta[-2]) / (h[-1] + h[-2])
    if np.sign(mn) != np.sign(delta[-1]):
        mn = 0.0
    elif abs(mn) > 3 * abs(delta[-1]):
        mn = 3 * delta[-1]
    m[-1] = mn

    return m


def pchip_evaluate(x: np.ndarray, y: np.ndarray, x_new: np.ndarray) -> np.ndarray:
    m = pchip_slopes(x, y)
    y_new = np.empty_like(x_new)

    for i, xv in enumerate(x_new):
        if xv <= x[0]:
            k = 0
        elif xv >= x[-1]:
            k = len(x) - 2
        else:
            k = np.searchsorted(x, xv) - 1

        h = x[k + 1] - x[k]
        t = (xv - x[k]) / h

        h00 = 2 * t**3 - 3 * t**2 + 1
        h10 = t**3 - 2 * t**2 + t
        h01 = -2 * t**3 + 3 * t**2
        h11 = t**3 - t**2

        y_new[i] = h00 * y[k] + h10 * h * m[k] + h01 * y[k + 1] + h11 * h * m[k + 1]

    return y_new

def main() -> None:
    parser = argparse.ArgumentParser(description="Plot BenchmarkDotNet CSV results.")
    parser.add_argument(
        "--csv",
        default="BenchmarkDotNet.Artifacts/results/DataTypes.Benchmarks.ComplexityBenchmarks-report.csv",
        help="Path to BenchmarkDotNet CSV report.",
    )
    parser.add_argument(
        "--out",
        default="benchmark-plots",
        help="Output folder for generated plot images.",
    )
    args = parser.parse_args()

    csv_path = Path(args.csv)
    out_dir = Path(args.out)

    if not csv_path.exists():
        raise FileNotFoundError(f"CSV report not found: {csv_path}")

    out_dir.mkdir(parents=True, exist_ok=True)

    raw = pd.read_csv(csv_path)
    df = raw[["Method", "N", "Mean", "Allocated"]].copy()
    df["N"] = pd.to_numeric(df["N"], errors="raise")
    df["MeanNs"] = df["Mean"].map(parse_numeric_with_unit)
    df["AllocatedKB"] = df["Allocated"].map(parse_size_kb)

    plot_metric(
        df,
        metric_col="MeanNs",
        y_label="Mean Time (ns)",
        title="Benchmark Runtime vs N (Smoothed)",
        output_path=out_dir / "runtime_ns_by_method.png",
        x_log_scale=False,
        y_log_scale=False,
    )

    plot_metric(
        df,
        metric_col="AllocatedKB",
        y_label="Allocated Memory (KB)",
        title="Allocated Memory vs N (Smoothed)",
        output_path=out_dir / "allocated_kb_by_method.png",
        x_log_scale=False,
        y_log_scale=False,
    )

    print(f"Saved plots to: {out_dir.resolve()}")


if __name__ == "__main__":
    main()
