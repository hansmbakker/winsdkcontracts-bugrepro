# winsdkcontracts-bugrepro

Reproduction steps:
1. open `bugrepro.sln`
1. set NuimoDemoApp as startup project
1. if needed, change the solution configuration from Any CPU to x86/x64/ARM to make the UWP app deploy
1. try building the solution

Errors like
```
3>  CSC : error CS1704: An assembly with the same simple name 'Windows.System.SystemManagementContract' has already been imported. Try removing one of the references (e.g. 'C:\Users\xxxxx\.nuget\packages\microsoft.windows.sdk.contracts\10.0.19041.1\ref\netstandard2.0\Windows.System.SystemManagementContract.winmd') or sign them to enable side-by-side.
3>  CSC : error CS1704: An assembly with the same simple name 'Windows.Foundation.UniversalApiContract' has already been imported. Try removing one of the references (e.g. 'C:\Users\xxxxx\.nuget\packages\microsoft.windows.sdk.contracts\10.0.19041.1\ref\netstandard2.0\Windows.Foundation.UniversalApiContract.winmd') or sign them to enable side-by-side.
3>  CSC : error CS1704: An assembly with the same simple name 'Windows.Foundation.FoundationContract' has already been imported. Try removing one of the references (e.g. 'C:\Users\xxxxx\.nuget\packages\microsoft.windows.sdk.contracts\10.0.19041.1\ref\netstandard2.0\Windows.Foundation.FoundationContract.winmd') or sign them to enable side-by-side.
3>  CSC : error CS1704: An assembly with the same simple name 'Windows.AI.MachineLearning.MachineLearningContract' has already been imported. Try removing one of the references (e.g. 'C:\Users\xxxxx\.nuget\packages\microsoft.windows.sdk.contracts\10.0.19041.1\ref\netstandard2.0\Windows.AI.MachineLearning.MachineLearningContract.winmd') or sign them to enable side-by-side.
```

come up
