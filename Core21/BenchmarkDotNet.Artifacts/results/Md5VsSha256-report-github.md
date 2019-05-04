``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742189 Hz, Resolution=364.6722 ns, Timer=TSC
.NET Core SDK=2.1.505
  [Host] : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  Core   : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
| Method |     Job | Runtime | IsBaseline |     N |      Mean |     Error |    StdDev | Scaled | ScaledSD | Rank |
|------- |-------- |-------- |----------- |------ |----------:|----------:|----------:|-------:|---------:|-----:|
| **Sha256** | **Default** |     **Clr** |       **True** |  **1000** |        **NA** |        **NA** |        **NA** |      **?** |        **?** |    **?** |
| Sha256 |    Core |    Core |    Default |  1000 |  6.739 us | 0.1317 us | 0.1568 us |      ? |        ? |    1 |
|        |         |         |            |       |           |           |           |        |          |      |
|    Md5 | Default |     Clr |       True |  1000 |        NA |        NA |        NA |      ? |        ? |    ? |
|    Md5 |    Core |    Core |    Default |  1000 |  3.119 us | 0.0707 us | 0.0627 us |      ? |        ? |    1 |
|        |         |         |            |       |           |           |           |        |          |      |
| **Sha256** | **Default** |     **Clr** |       **True** | **10000** |        **NA** |        **NA** |        **NA** |      **?** |        **?** |    **?** |
| Sha256 |    Core |    Core |    Default | 10000 | 64.594 us | 1.2758 us | 2.6911 us |      ? |        ? |    1 |
|        |         |         |            |       |           |           |           |        |          |      |
|    Md5 | Default |     Clr |       True | 10000 |        NA |        NA |        NA |      ? |        ? |    ? |
|    Md5 |    Core |    Core |    Default | 10000 | 27.094 us | 0.1606 us | 0.1341 us |      ? |        ? |    1 |

Benchmarks with issues:
  Md5VsSha256.Sha256: Job-IARAOW(Runtime=Clr, IsBaseline=True) [N=1000]
  Md5VsSha256.Md5: Job-IARAOW(Runtime=Clr, IsBaseline=True) [N=1000]
  Md5VsSha256.Sha256: Job-IARAOW(Runtime=Clr, IsBaseline=True) [N=10000]
  Md5VsSha256.Md5: Job-IARAOW(Runtime=Clr, IsBaseline=True) [N=10000]
