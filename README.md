![Azure DevOps builds](https://img.shields.io/azure-devops/build/twoteesbrett/dd494a5e-71a9-497f-9e0a-717d34eae722/2)
![Azure DevOps builds](https://img.shields.io/azure-devops/tests/twoteesbrett/dd494a5e-71a9-497f-9e0a-717d34eae722/2)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet Badge](https://buildstats.info/nuget/Spectrum.Ird)](https://www.nuget.org/packages/Spectrum.Ird)

# New Zealand Bank Account Validation

A library to validate bank account numbers according to the "Resident Withholding Tax (RWT) and Non-Resident Withholding Tax (NRWT)" specification published by the New Zealand Inland Revenue Department (IRD).

The specification used in this implementation is [here](https://www.ird.govt.nz/-/media/project/ir/documents/income-tax/withholding-taxes/rwt-nrwt-withholding-tax-certificate/2020-rwt-and-nrwt-certificate-filing-specification.pdf).

## Installation
This library is distributed with Nuget. The package can be installed by:

```ps1
Install-Package Spectrum.Ird
```

## Usage
Import the namespace.

```csharp
using Spectrum.Ird;
```

### Validation
Create an instance of the `NZBankAccount` with a bank account number in its constituent parts. That is, its bank, branch, account base and suffix. Call the `IsValid()` method to validate it.

```csharp
var bank = 1;
var branch = 902;
var accountBase = 68389;
var suffix = 0;

var account = new NZBankAccount(bank, branch, accountBase, suffix);
var isValid = account.IsValid();
```

### Parsing

An instance can also be created by parsing a `string` value in the format `XX-XXXX-XXXXXXX-XX(X)` where `X` is a digit and the suffix can be either 2 or 3 digits. Hyphens, spaces or periods can be used as separators. If the value cannot be parsed, `null` is returned.

Parsing an account number does not validate it. Once an instance has been created, it can then be validated.

```csharp
var account = NZBankAccount.Parse("01-0902-0068389-00");
var isValid = account?.IsValid() ?? false;
```

A `TryParse()` method is also available:

```csharp
if (NZBankAccount.TryParse("01-0902-0068389-00", out NZBankAccount account))
{
    var isValid = account.IsValid();
}
```

### Friendly Display
After an account number has been instantiated, the `ToString()` method can be called to get a friendly display of the account number, hyphen separated.

```csharp
// arrange
var account = new NZBankAccount(1, 902, 68389, 0);

// act
var result = account.ToString();

// assert
Assert.AreEqual("01-0902-0068389-00", result);
```

### Static Validation
A static method of validation is available.

```csharp
var isValid = NZBankAccount.IsValid(bank, branch, accountBase, suffix);
```

## Release Notes
#### 2.0.0
2020-09-21
* Changed the namespace from `Spectrum.IrdValidation` to `Spectrum.Ird`.
* Renamed `NZBankAccountValidator` to `NZBankAccount`.
* Removed AccountNumber property as it is misleading and could be confused with ToString(). This is used privately as part of the validation algorithm.
* Added Parse() to accept bank account numbers in a "XX-XXXX-XXXXXXX-XX(X)" format.

#### 1.0.2
2020-09-17
* Override ToString() to output a human-friendly formatted account number.

#### 1.0.1
2020-09-12
* Added XML documentation.

#### 1.0.0
2020-09-06
* Initial release 
