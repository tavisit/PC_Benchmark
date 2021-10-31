![UTCN](https://doctorat.utcluj.ro/images/utcn-logo.png)
## Student Octavian-Mihai Matei
### Group 30431
___
___
___
# PC Benchmark application in C#
### QR to the [github repository](https://github.com/tavisit/PC_Benchmark)
![image](https://user-images.githubusercontent.com/28965189/139591086-13d46bde-bc08-434e-9dd7-14d024f98768.png)
# Table of contents
- [Introduction](#introduction)
  * [Goal](#goal)
  * [Specifications](#specifications)
- [Bibliographic Study](#bibliographic-study)
- [Planning](#planning)
- [Analysis](#analysis)
  * [CPU analysis](#cpu-analysis)
    + [Frequency](#frequency)
    + [Speed of simple operations](#speed-of-simple-operations)
  * [RAM analysis](#ram-analysis)
    + [Dimensions](#ram-dimensions)
    + [Health](#ram-health)
    + [Speed](#ram-speed)
  * [Storage analysis](#storage-analysis)
    + [Dimensions](#storage-dimensions)
    + [Health](#storage-health)
    + [Speed](#storage-speed)
  * [Microsoft Defined Data Structures Information](#microsoft-defined-data-structures-information)
    * [CPU](#cpu)
    * [GPU](#gpu)
    * [Battery](#battery)
    * [RAM](#ram)
    * [Storage](#storage)
- [Design](#design)
  * [Local application](#local-application-design)
    + [CPU Benchmark Design](#cpu-benchmark-design)
    + [RAM Benchmark Design](#ram-benchmark-design)
    + [Storage Benchmark Design](#storage-benchmark-design)
    + [Microsoft Defined Data Structures Integration Design](#microsoft-defined-data-structures-integration-design)
    + [GUI Design](#gui-design)
  * [Service Design](#service-design)
- [Implementation](#implementation)
  * [Local application](#local-application)
    + [CPU Benchmark](#cpu-benchmark)
    + [RAM Benchmark](#ram-benchmark)
    + [Storage Benchmark](#storage-benchmark)
    + [Microsoft Defined Data Structures Integration](#microsoft-defined-data-structures-integration)
    + [GUI](#gui)
  * [Service](#service)
- [Testing and validation](#testing-and-validation)
- [Conclusions](#conclusions)
- [Bibliography](#bibliography)
___
# Introduction
## Goal
The goal of this project is to design, implement and test a benchmark application that runs on a machine and can determine the following statistics:
- For the CPU: Type, Frequency and speed of simple operations
- For the RAM: Dimension, Health, Speed of RAM
- For the Storage: Dimension, Health, Speed of Storage

These tests should be comparable with the system status and online information provided with the hardware, but could also be ranked on a service against other machines, in order to determine the efficiency of the current system.

## Specifications
For the local application, the program should apply specific algorithms, in order to determine in the most efficient way the status of the system, as well as work out any major flaw in the RAM configuration. It will run on the machine directly, to be able to access the hardware components more easily. After the tests are done, the results will be displayed in a user-friendly way to the screen and a rank fetched from the service will be displayed. If the user wants to share any information with the service, they will can do it.
___
# Bibliographic Study
For this kind of application, there are lots of information in different categories, but the main sites were the [Intel website](https://www.intel.com/content/www/us/en/architecture-and-technology/64-ia-32-architectures-software-developer-vol-2a-manual.html), the [Microsoft documentation](https://docs.microsoft.com), but also univeristy studies and niche-websites. All of them can be consulted in the [bibliography](#bibliography).

#### CPU Benchmarking
Modern CPUs have a lot of fine tunning in order to maximise the efficiency of the hardware, so a lot of work has to be done in order to ensure consistent metrics and repeatable measurements. In order to do that, we have the ability to set the afinity of the processor, manage the transition of the compiler from readable code to machine code, but also a way to asses if the measurements are correct, by checking the internal library managed by Microsoft.
We also have to bind each iteration of the run to one physical processor with the command export ```OMP_PROC_BIND=true```[^1](#bibliography) and we have to take into account the hyperthreading of the processor by dividing by 2 the physical number of processors.

For the simple operations, a simple sum from 1 to 1.000.000 should suffice. The same would be true for the substraction operation.

#### RAM Benchmarking
There are a lot of algorithms to asses the health of the RAM, from MSCAN algorithms to GALPAT or WALPAT[^6](#bibliography)[^7](#bibliography). All of these algorithms test the read-write ability of the system of specific RAM cells zones so they are all good benchmarks for the health consideration.
We will use the sequential vs random write-read modes, ways explained in the photo bellow:

![](https://www.deskdecode.com/wp-content/uploads/2019/06/Random_vs_sequential_access-1.png)

That means data, as bytes, will be declared as a vector/array in order to test the sequential access health and as linked lists for the random access. The data used will either be 0xFF or 0x00 in chunks of 32768 addresses (2^16). In that way, we can assure the user of the efficiency of the algorithm and the real health of the RAM.

The speed of the RAM would be the time the algorithm described above takes to write-read into the system memory.

#### Storage Benchmarking

The user should be allowed to choose a drive on which the test takes place. For example, ```Choose Drive C ``` will make the application to run on that drive, in order to test the speed and health of the partition.

The storage benchmarking will be similar to the one of the RAM, with the exception that the data must be written on the actual storage, not in the RAM. There is also the problem where the storage will write in the cache memory[^9](#bibliography) as well as in the actual file, so the test will be nullified. Windows creates a 256 KB buffer that is read into a 256 KB cache "slot" in system address space when it is first requested by the cache manager during a file read operation which can be explained with the photo below. This can be turned off by setting the flag FILE_FLAG_NO_BUFFERING on off. 

The speed of the Storage would be the time the algorithm described above takes to write-read into the system storage.

![](https://docs.microsoft.com/en-us/windows/win32/fileio/images/fig3.png)

#### Microsoft Defined Data Structures Information
Microsoft provides with a lot of information about the system, information which can be used to validate and display as "Expected values" to the user. The same information can include the type of the CPU, the battery status, RAM type/frequency etc. These data structures can be used with a simple method call to obtain a lot of information about the current system, without the need to implement complex algorithms and manual testing of the performance.

#### Service Side
The application will have the ability to display similar systems or better ones, in order to tell the user what is wrong and what can be changed. Moreover, the system will have the ability to upload the system specifications on the service to be used by other people. From our experience, the most facil way for us to implement a Saas[^10](#bibliography) is to use ASP.NET with a MVC methodology.

![](https://static.javatpoint.com/tutorial/reactjs/images/react-flux-vs-mvc.png)

___
# Planning
- Until 19th October: 
  * Research the subject and make the introduction, bibliographic study and planning part of the documentation
- Until 2nd November: 
  * Write CPU analysis chapter in documentation
  * Write the design of the CPU benchmark classes in documentation
  * Implement the CPU benchmark classes
  * Write the implementation in documentation
- Until 16th November:
  * Write RAM and Storage analysis chapter in documentation
  * Write the design of the RAM and Storage benchmark classes in documentation
  * Implement the RAM and Storage benchmark classes
  * Write the implementation in documentation
- Until 30th November:
  * Write the design of the Microsoft Defined Data Structures Integration in documentation
  * Implement the Microsoft Defined Data Structures Integration classes
  * Write the implementation in documentation
  * Write the design of the GUI in documentation
  * Implement the GUI classes
  * Write the implementation in documentation
- Until 14th December:
  * Write Design of the Service in documentation
  * Implement the service benchmark classes
  * Write the implementation in documentation
  * Finalize the documentation
- Present the project on the 14th December
___
# Analysis

## CPU analysis

### Frequency

By analysing the algorithms for the computation of the frequency of the CPU, three choices were selected for the ease of coding and their clarity. All the results from the algorithms are averaged and the CPU frequency is resulted.

#### First algorithm - Sha256 hashing
The SHA-256 algorithm is one flavor of Secure Hash Algorithm 2, which was created by the NSA in 2001 as a successor to SHA-1. SHA-256 is a patented cryptographic hash function that outputs a value that is 256 bits long.
What is the difference between encryption and hashing? In encryption, data is transformed into a secure format that is unreadable unless the recipient has a key. In its encrypted form, the data may be of unlimited size, often just as long as when unencrypted. In hashing, by contrast, data of arbitrary size is mapped to data of fixed size. For example, a 512-bit string of data would be transformed into a 256-bit string through SHA-256 hashing.[^15](#bibliography)

```
Mathematical behaviour of SHA256
Ch(x, y,z) = (x ∧ y) ⊕ (¬x ∧ z) (4.2)
Maj(x, y,z) = (x ∧ y) ⊕ (x ∧ z) ⊕ ( y ∧ z) (4.3)
∑{256}0 (x) = ROTR 2(x) ⊕ ROTR 13(x) ⊕ ROTR 22(x)
∑{256}1 (x) = ROTR 6(x) ⊕ ROTR 11(x) ⊕ ROTR 25(x)
σ{256}0 x = ROTR 7(x) ⊕ ROTR 18(x) ⊕ SHR 3(x)
σ{256}1 x = ROTR 17(x) ⊕ ROTR 19(x) ⊕ SHR 10(x)
```

As can be seen from the mathematical behaviour, this benchmark was designed to test the logical speed of the ALU of the CPU.

#### Second algorithm - Exponentiation function
Exponentiation is a mathematical operation, written as b^n, involving two numbers, the base b and the exponent or power n, and pronounced as "b raised to the power of n". When n is a positive integer, exponentiation corresponds to repeated multiplication of the base, that is: ```b^n = b*b*b*b*...*b*b*b```

As can be seen from the mathematical behaviour, this benchmark was designed to test the multiplication speed of the ALU of the CPU

#### Third algorithm - For loop
A for-loop is a computer-science concept that has two parts: a header specifying the iteration, and a body which is executed once per iteration. The header explicitly tells the compiler how the loop should behave, by storing the current iteration index, a condition for stop and an increment of the index. On the other hand, the body has implemented the actual code that hav to be run multiple times, but also breaking statements that exit the loop. A simple example in assembly:
```
MOV	CL, 10
L1:
<LOOP-BODY>
DEC	CL
JNZ	L1
```

As can be seen from the mathematical behaviour, this benchmark was designed to test the speed of the entire CPU.

### Speed of simple operations

By analysing the algorithms for the computation of speed of simple operations done by the CPU, a simple algorithm was considered, because it needs only the basic ALU behaviour to be executed (addition and substraction). For this, a loop that adds and substracts a given int was considered because it needs only around 3-4 clock cycles to be completed. A simple example in assembly of the behaviour:
```
// Addition
mov     eax, 14
mov     ebx, 10
add     eax, ebx
// Substraction
mov     eax, 14
mov     ebx, 10
sub     eax, ebx
```

## RAM analysis

### RAM Dimensions

### RAM Health

### RAM Speed

## Storage analysis

### Storage Dimensions

### Storage Health

### Storage Speed

## Microsoft Defined Data Structures Information

### CPU

### GPU

### Battery

### RAM

### Storage
___
# Design
## Local application design
### CPU Benchmark Design
The user will not interact directly with these algorithms, but the application will, so bellow it is described the use case diagram:

As seen from the use case, the class should provide only three public methods:

1. Constructor -> Basic Constructor
2. RunFrequencyTests -> Run all the frequency tests and measure their execution time
3. RunSimpleOperationsTests -> Run all the simple operation tests and measure their execution time

All the other private methods should be:

1. BenchmarkSHA256 -> Run a benchmark which runs a simple string to sha256 algorithm and measure its execution frequency
2. BenchmarkPower -> Run a benchmark which runs the power function and measure its execution frequency
3. BenchmarkForLoops -> Run a benchmark which runs a big loop and measure its execution frequency
4. BenchmarkSimpleOperations -> Run a benchmark which runs a simple addition and substraction and measure its clock cycles

### RAM Benchmark Design
### Storage Benchmark Design
### Microsoft Defined Data Structures Integration Design
### GUI Design
## Service Design
___
# Implementation
## Local application
### CPU Benchmark
![](https://i.imgur.com/J0pbr40.png)
### RAM Benchmark
### Storage Benchmark
### Microsoft Defined Data Structures Integration
### GUI
## Service
___
# Testing and validation
___
# Conclusions
___
# Bibliography
1. [Intel Architecture information](https://www.intel.com/content/www/us/en/architecture-and-technology/64-ia-32-architectures-software-developer-vol-2a-manual.html)
2. [CPUID type](https://docs.microsoft.com/en-us/cpp/intrinsics/cpuid-cpuidex?redirectedfrom=MSDN&view=msvc-160)
3. [CPUID wikipage](https://en.wikipedia.org/wiki/CPUID#EAX.3D4_and_EAX.3DBh:_Intel_thread.2Fcore_and_cache_topology)
4. [Stackoverflow question with a lot of useful links about CPU](https://stackoverflow.com/questions/13772567/how-to-get-the-cpu-cycle-count-in-x86-64-from-c/51907627#51907627)
5. [RAM information](https://en.wikipedia.org/wiki/Random-access_memory)
6. [Memory Testing](https://eecs.ceas.uc.edu/~jonewb/Memory.pdf)
7. [On-the-fly RAM tests](https://www.embedded.com/on-the-fly-ram-tests/)
8. [Storage Benchmark](https://bruun.co/2012/02/07/easy-cpp-benchmarking)
9. [Storage cache problem](https://docs.microsoft.com/en-us/windows/win32/fileio/file-caching?redirectedfrom=MSDN)
10. [Software as a service](https://en.wikipedia.org/wiki/Software_as_a_service)
11. [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)
12. [Microsoft battery Information](https://docs.microsoft.com/en-us/windows/win32/power/battery-information-str)
13. [Microsoft CPU Information](https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor)
14. [Microsoft RAM Information](https://docs.microsoft.com/en-us/previous-versions/windows/desktop/virtual/msvm-memory)
15. [Sha 256](https://www.n-able.com/blog/sha-256-encryption)
