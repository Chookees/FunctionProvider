# FunctionProvider
This .Net8 based .dll can be imported in any C# Project.
This DLL is designed to streamline and enhance the development process for C# projects by consolidating a variety of essential functions into a single, easy-to-use, and efficient library.

## Table of Content
1) [Key Benefits](https://github.com/Chookees/FunctionProvider/tree/main?tab=readme-ov-file#key-benefits)
2) [Functions](https://github.com/Chookees/FunctionProvider/tree/main#functions)
3) [Example Usage](https://github.com/Chookees/FunctionProvider/tree/main#example-usage)

# Key Benefits:
- Centralized Functionality: Combines multiple commonly used functions, reducing redundancy and simplifying code maintenance.
- Ease of Use: Provides a straightforward API, making it accessible for developers of all skill levels.
- Efficiency: Optimized for performance to ensure minimal overhead and fast execution.

# Functions
1) [IO](https://github.com/Chookees/FunctionProvider/tree/main#1-io)
2) [Math](https://github.com/Chookees/FunctionProvider/tree/main#2-math)
5) [Various](https://github.com/Chookees/FunctionProvider/tree/main#5-various)

## 1. IO
- File
    - Change Directory of current File
    - Change Name of current File
    - Change Extension of current File
    - Read File
    - Edit File
    - and more..
- Directory
    - Get Drives
    - Get Drive with most free space
    - Get all files from a directory
    - Get specific file from directory

## 2. Math
- Basic
    - PI
    - E
    - Rounding to two numbers after comma (decimal, double)
    - Power of
    - Squareroot
    - Calculate standard deviation
    - and more..
- Advanced
    - Tangent calculation
    - Heat Equation
    - Torsion calculation
    - Curvature calculation
    - 2-D Wave Equation
    - and more..
- Sort
    - Bubble sort
    - Selection sort
    - Insertion sort
    - Merge sort
    - Quick sort
    - Heap sort
    - Shell sort

## 3. Various
- GUID
    - Generate
    - Parse to string
    - IsValidGuid
    - GetHashcode
    - Parse to guid
- String manipulation
    - To camel case
    - Compress string
    - Decompress string
    - Word frequency
    - Caesar cipher
    - and more..
- Random
    - Generate random int
    - Generate random string
    - Shuffle array
    - Generate secure random string
    - Generate Random permutation
    - and more..
- Validation
    - IsValidEmail
    - IsValidPhoneNumber
    - IsValidUrl

# Example Usage
1) Import the .dll to your Project.
2) Add a using
   > using FunctionProvider;
    - Or if you need just one of all the Functions:
   > using FunctionProvider.Various;
3) Use a function:
   > Guid myGuid = FunctionProvider.Various.GUID.Task.Generate();
   - if you set your using like this you could:
   > using FP = FunctionProvider.Various;
   > Guid myGuid = FP.GUID.Task.Generate();

Following Code represents the usecase of you wanting to delete a specific file:
```
namespace FileDeleter
{
    using FPIO = FunctionProvider.IO;
    public class FileDeleter
    {
        public FileDeleter(string path)
        {
            FPIO.ReturnCodes code = FPIO.File.Task.DeleteFile(path);

            if (code != FPIO.ReturnCodes.Success)
            {
                // File deletion failed.
                throw new Exception();
            }
        }
    }
}
```
