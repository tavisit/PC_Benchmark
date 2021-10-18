![UTCN](https://doctorat.utcluj.ro/images/utcn-logo.png)
## Student Octavian-Mihai Matei
### Group 30431
___
___
___
# PC Benchmark application in C#
# Table of contents
- [Introduction](#introduction)
  * [Goal](#goal)
  * [Specifications](#specifications)
- [Bibliographic Study](#bibliographic-study)
- [Planning](#planning)
- [Analysis](#analysis)
  * [CPU analysis](#cpu-analysis)
    + [Type of processor](#type-of-processor)
    + [Frequency](#frequency)
    + [Speed of simple operations](#speed-of-simple-operations)
  * [RAM analysis](#ram-analysis)
    + [Dimensions](#dimensions)
    + [Health](#health)
    + [Transfer speed](#transfer-speed)
  * [Storage analysis](#storage-analysis)
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
- For the RAM: Dimension, Health and Transfer Speed
- For the Storage the speed of the location assigned
These tests should be comparable with the system status and online information provided with the hardware, but could also be ranked on a service against other machines, in order to determine the efficiency of the current system.
## Specifications
For the local application, the program should apply specific algorithms, in order to determine in the most efficient way the status of the system, as well as work out any major flaw in the RAM configuration. It will run on the machine directly, to be able to access the hardware components more easily. After the tests are done, the results will be displayed in a user-friendly way to the screen and a rank fetched from the service will be displayed. If the user wants to share any information with the service, they will can do it.
___
# Bibliographic Study
For this kind of application, there are lots of information in different categories, but the main sites were the [Intel website](https://www.intel.com/content/www/us/en/architecture-and-technology/64-ia-32-architectures-software-developer-vol-2a-manual.html), the [Microsoft documentation](https://docs.microsoft.com), but also univeristy studies and niche-websites. All of them can be consulted in the [bibliography](#bibliography).

#### CPU Benchmarking
Modern CPUs have a lot of fine tunning in order to maximise the efficiency of the hardware, so a lot of work has to be done in order to ensure consistent metrics and repeatable measurements. In order to do that, we have the ability to set the afinity of the processor, manage the transition of the compiler from readable code to machine code, but also a way to asses if the measurements are correct, by checking the internal library managed by Microsoft.

#### RAM Benchmarking
There are a lot of algorithms to asses the health of the RAM, from MSCAN algorithms to GALPAT or WALPAT[^6](#bibliography)[^7](#bibliography). All of these algorithms test the read-write ability of the system of specific RAM cells zones so they are all good benchmarks for the health consideration.
For the transfer speed of the RAM, the read and write speeds will be examined separatly to test the random speed and the sequential speed of the RAM which both have real world implications.

![](https://www.deskdecode.com/wp-content/uploads/2019/06/Random_vs_sequential_access-1.png)


#### Storage Benchmarking
The storage benchmarking will be similar to the one of the RAM, with the exception that the data must be written on the actual storage, not on the cache memory[^9](#bibliography). Windows creates a 256 KB buffer that is read into a 256 KB cache "slot" in system address space when it is first requested by the cache manager during a file read operation which can be explained with the photo below. This can be turned off by setting the flag FILE_FLAG_NO_BUFFERING on off. 

![](https://docs.microsoft.com/en-us/windows/win32/fileio/images/fig3.png)

#### Microsoft Defined Data Structures Information
Microsoft provides with a lot of information about the system, information which can be used to validate and display as "Expected values" to the user. The same information can include the type of the CPU, the battery status, RAM type/frequency etc. These data structures can be used with a simple method call to obtain a lot of information about the current system, without the need to implement complex algorithms and manual testing of the performance.

#### Service Side
The application will have the ability to display similar systems or better ones, in order to tell the user what is wrong and what can be changed. Moreover, the system will have the ability to upload the system specifications on the service to be used by other people. From our experience, the most facil way for us to implement a Saas[^10](#bibliography) is to use ASP.NET with a MVC methodology.
![](https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/MVC-Process.svg/1200px-MVC-Process.svg.png)

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
- Until 16th December:
  * Write Design of the Service in documentation
  * Implement the service benchmark classes
  * Write the implementation in documentation
- Present the project on the 16th December
___
# Analysis
## CPU analysis
### Type of processor
### Frequency
### Speed of simple operations
## RAM analysis
### Dimensions
### Health
### Transfer speed
## Storage analysis
### Health
### Transfer speed
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
### RAM Benchmark Design
### Storage Benchmark Design
### Microsoft Defined Data Structures Integration Design
### GUI Design
## Service Design
___
# Implementation
## Local application
### CPU Benchmark
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
