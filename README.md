![UTCN](https://doctorat.utcluj.ro/images/utcn-logo.png)
## Student Octavian-Mihai Matei
### Group 30431
<div style="page-break-after: always;"></div>

# PC Benchmark application in C#

### QR to the [github repository](https://github.com/tavisit/PC_Benchmark)
![image](https://user-images.githubusercontent.com/28965189/139591086-13d46bde-bc08-434e-9dd7-14d024f98768.png)
<div style="page-break-after: always;"></div>

# Table of contents

- [Introduction](#introduction)
  * [Goal](#goal)
  * [Specifications](#specifications)
- [Bibliographic Study](#bibliographic-study)
- [Planning](#planning)
- [Analysis](#analysis)
  * [CPU analysis](#cpu-analysis)
    + [MIPS](#MIPS)
    + [Speed of simple operations](#speed-of-simple-operations)
  * [RAM analysis](#ram-analysis)
    + [Health](#ram-health)
  * [Storage analysis](#storage-analysis)
    + [Health](#storage-health)
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
<div style="page-break-after: always;"></div>

# Introduction

## Goal
The goal of this project is to design, implement and test a benchmark application that runs on a machine and can determine the following statistics:
- For the CPU: Type, MIPS and speed of simple operations
- For the RAM: Dimension, Health, Speed of RAM
- For the Storage: Dimension, Health, Speed of Storage

These tests should be comparable with the system status and online information provided with the hardware, but could also be ranked on a service against other machines, in order to determine the efficiency of the current system.

## Specifications
For the local application, the program should apply specific algorithms, in order to determine in the most efficient way the status of the system, as well as work out any major flaw in the RAM configuration. It will run on the machine directly, to be able to access the hardware components more easily. After the tests are done, the results will be displayed in a user-friendly way to the screen and a rank fetched from the service will be displayed. If the user wants to share any information with the service, they will can do it.
<div style="page-break-after: always;"></div>

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
<div style="page-break-after: always;"></div>

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
<div style="page-break-after: always;"></div>

# Analysis

## CPU analysis

### MIPS

By analysing the algorithms for the computation of the MIPS of the CPU, three choices were selected for the ease of coding and their clarity. All the results from the algorithms are averaged and the CPU MIPS is resulted.

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

### RAM Health

## Storage analysis

### Storage Health

## Microsoft Defined Data Structures Information

The Computer System Hardware category groups classes together that represent hardware related objects. Examples include input devices, hard disks, expansion cards, video devices, networking devices, and system power. These classes provide information about the system without any computation, only using ManagementObjectSearcher object, which retrieves a collection of management objects based on a specified query. This class is one of the more commonly used entry points to retrieving management information. For example, it can be used to enumerate all disk drives, network adapters, processes and many more management objects on a system, or to query for all network connections that are up, services that are paused, and so on. When instantiated, an instance of this class takes as input a WMI query represented in an ObjectQuery or its derivatives, and optionally a ManagementScope representing the WMI namespace to execute the query in. It can also take additional advanced options in an EnumerationOptions. When the Get() method on this object is invoked, the ManagementObjectSearcher executes the given query in the specified scope and returns a collection of management objects that match the query in a ManagementObjectCollection.

<div style="page-break-after: always;"></div>

# Design

## Local application design

#### Class Diagram
![](https://github.com/tavisit/PC_Benchmark/blob/main/Resources/ClassDiagram.png?raw=true)

#### Class explanation

##### Controller

The controller class should have 2 public classes:
1. DisplayComputedData -> has no parameters and returns a complex object with all the data that was computed by the algorithms implemented in the application
2. DisplayMicrosoftData -> has no parameters and returns a complex object with all the data from the Microsoft Library

##### UI

The UI is a cluster of Microsoft forms that display the information to the user. These are composed of two parts:
1. The actual UI that draws the information
2. An internal controller that manages the data

##### CPU

The CPU class should have 2 public classes:
1. RunMIPSTests -> has no parameters and returns a float value representing the MIPS of the machine
2. RunSImpleOperationTests -> has no parameters and returns a float value representing the number of clock cycles the CPU needs to perform simple operations

##### RAM

The RAM class should have 3 public classes:
1. DimensionRAM -> has no parameters and returns a float value that represents the space available on the RAM chip in Mb
2. HealthRAM -> has no parameters and returns a float value representing the health of the RAM stick from 0 to 100% healthy
3. SpeedRAM -> has no parameters and returns a float value representing the MIPS of the RAM stick in MHz

##### Storage

The Storage class should have 3 public classes:
1. DimensionStorage -> has a string parameter that represents the path/drive for analysis and returns a float value that represents the space available on the storage path in Mb
2. HealthStorage -> has a string parameter that represents the path/drive for analysis and returns a float value representing the health of the storage path from 0 to 100% healthy
3. SpeedStorage -> has a string parameter that represents the path/drive for analysis and returns a float value representing the MIPS of the storage in MHz

##### MicrosoftBenchmark

The MicrosoftBenchmark class should have 5 public classes:
1. CpuData -> has no parameters and returns a complex object representing CPU information obtained by querring the Microsoft Library, from Win32_Processor[^17](#bibliography) (ProcName, Manufacturer, Version, NrCores, NrLogicalProcessors, NrThreads, CurrentClockSpeed, MaximumClockSpeed)
2. BatteryData -> has no parameters and returns a complex object representing battery information obtained by querring the Microsoft Library, from Win32_Battery[^17](#bibliography) (Name, Status, EstimatedChargeRemaining, FullChargeCapacity, DesignCapacity, MaxRechargeTime, DesignVoltage)
3. RamData -> has no parameters and returns a complex object representing RAM information obtained by querring the Microsoft Library, from Win32_PhysicalMemory[^17](#bibliography) (Name, Speed, MinVoltage, MaxVoltage, Status, Capacity)
4. StorageData -> has no parameters and returns a complex object representing storage information obtained by querring the Microsoft Library, from Win32_DiskDrive[^17](#bibliography) (Name, Model, BytesPerSector, Size, Status, TotalSectors, Partitions, Manufacturer) 
5. GpuData -> has no parameters and returns a complex object representing gpu information obtained by querring the Microsoft Library, from Win32_VideoController[^17](#bibliography) (Name, DriverVersion, LastErrorCode, MinRefreshRate, MaxRefreshRate, Status, VideoArchitecture, VideoMemoryType, VideoProcessor)


### CPU Benchmark Design
The user will not interact directly with these algorithms, but the application will, so bellow it is described the use case diagram:

![](https://github.com/tavisit/PC_Benchmark/blob/main/Resources/USE%20CASES.png?raw=true)

As seen from the use case, the class should provide only three public methods:

1. Constructor -> Basic Constructor
2. RunMIPSTests -> Run all the MIPS tests and average their MIPS results
3. RunSimpleOperationsTests -> Run all the simple operation tests and add their execution time

The two public custom methods should force the CPU to run only on one thread and to prioritize the benchmark execution. This should be done on all threads, in order to average the entire CPU speed and characteristics. The following code will be used:
```
foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
{
    pt.IdealProcessor = threadIndex;
    pt.ProcessorAffinity = (IntPtr)(1 << threadIndex);
}
```

All the other private methods should be:

1. BenchmarkSHA256 -> Run a benchmark which runs a simple string to sha256 algorithm and measure its execution MIPS
2. BenchmarkPower -> Run a benchmark which runs the power function and measure its execution MIPS
3. BenchmarkForLoops -> Run a benchmark which runs a big loop and measure its execution MIPS
4. BenchmarkSimpleOperations -> Run a benchmark which runs a simple addition and substraction and measure its clock cycles

All the Benchmark named methods will run multiple times and average the results, in order to obtain a more consistent measurement.

### RAM Benchmark Design
### Storage Benchmark Design
### Microsoft Defined Data Structures Integration Design

The structure of the Microsoft Defined Structures Integration will be explained using the following Class Diagram:

![](https://github.com/tavisit/PC_Benchmark/blob/main/Resources/USE%20CASES.png?raw=true)

The usage of Lists is necessary in the case of:
- GpuInformation - because a system can have one or more Gpus (in the most cases, a integrated and dedicated one)
- RamInformation - because a system can have one or more Ram sticks inserted into the motherboard
- StorageInformation - because a system can have one or more storage solutions

### GUI Design
## Service Design
<div style="page-break-after: always;"></div>

# Implementation

## Local application
### CPU Benchmark
The implementation needed some libraries that should be mentioned here:
1. [System.Security.Cryptography](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=net-5.0) -> Library that creates and outputs the SHA of a given raw data string
2. [System.Environment](https://docs.microsoft.com/en-us/dotnet/api/system.environment?view=net-5.0) -> Library that detects the environment and outputs the number of physical cores
3. [System.Diagnostics.ProcessThread](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.processthread?view=net-5.0) -> Library that enables the programmer to use the threads and process of the computer
4. [System.Numerics](https://docs.microsoft.com/en-us/dotnet/api/system.numerics?view=net-5.0) -> Library that enables the use of large numbers for the MIPS calculation

The implementation of the public methods is the following:
##### RunMIPSTests
```
public float RunMIPSTests()
{
    int nrTests = 3;
    float averageCPU = 0;
    int processorCount = Environment.ProcessorCount;
    // For every physical processor
    for (int i=0;i< processorCount; i++)
    {
        // Enable the current processor and set the affinity to it
        foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
        {
            pt.IdealProcessor = i;
            pt.ProcessorAffinity = (IntPtr)(1 << i);
        }
        // measure the time passed for each of the available algorithms
        float currentCPUMIPS = BenchmarkSHA256(10000) + BenchmarkPower(10000) + BenchmarkForLoops(1000);
        averageCPU += currentCPUMIPS;
    }
    averageCPU /= (processorCount * nrTests);
    return averageCPU;
}
```

As it can be observed, for every physical processor, the application sets the the CPU affinity to that processor and then it computes the MIPS, returning the actual value.

##### RunSimpleOperationsTests
```
public float RunSimpleOperationsTests()
{
    float averageCPU = 0;
    int processorCount = Environment.ProcessorCount;
    // For every physical processor
    int nrTests = 100;
    for (int i = 0; i < processorCount; i++)
    {
        // Enable the current processor and set the affinity to it
        foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
        {
            pt.IdealProcessor = i;
            pt.ProcessorAffinity = (IntPtr)(1 << i);
        }
        // measure the time passed for each of the available algorithms
        averageCPU += BenchmarkSimpleOperations(nrTests);
    }
    averageCPU /= (nrTests * nrTests * 2);
    averageCPU /= processorCount;
    return averageCPU;
}
```

As it can be observed, for every physical processor, the application sets the the CPU affinity to that processor and then it computes the clock cycles, returning the actual value in clock cycles.

As for the actual tests, the private methods have the following implementation:

##### BenchmarkSHA256
```
private float BenchmarkSHA256(int nrTests)
{
    Stopwatch swTotal = new Stopwatch();
    BigInteger averageTimeSha256 = new BigInteger(0);
    for(int i=0;i< nrTests; i++)
    {
        Stopwatch sw = new Stopwatch();
        string data = RandomString(256);
        sw.Start();
        swTotal.Start();
        string returnSha256 = ComputeSha256Hash(data);
        sw.Stop();
        swTotal.Stop();
        // add to the average the partial execution time
        averageTimeSha256 = BigInteger.Add(averageTimeSha256, new BigInteger(sw.Elapsed.Ticks));
    }
    averageTimeSha256 = BigInteger.Divide(averageTimeSha256, new BigInteger(nrTests));
    return ((float)((float)averageTimeSha256 / (swTotal.Elapsed.TotalMilliseconds)));
}
```
This method has two clock, one for the actual number of cycles of execution of the algorithm, the other for the total miliseconds passed.
It will compute the sha256 hash of a random string and count the clock cycles.

##### BenchmarkPower

```
private float BenchmarkPower(int nrTests)
{
    Stopwatch swTotal = new Stopwatch();
    BigInteger averageTimePower = new BigInteger(0);
    for (int i = 0; i < nrTests; i++)
    {
        Stopwatch sw = new Stopwatch();
        BigInteger result = new BigInteger(0);
        BigInteger a = new BigInteger(3);
        int b = 128;
        sw.Start();
        result = BigInteger.Pow(a, b);
        sw.Stop();
        // add to the average the partial execution time
        averageTimePower = BigInteger.Add(averageTimePower, new BigInteger(sw.Elapsed.Ticks));
    }
}
```
This method has two clock, one for the actual number of cycles of execution of the algorithm, the other for the total miliseconds passed.
It will compute the power 128 of 3 and count the clock cycles.

##### BenchmarkForLoops
```
private float BenchmarkForLoops(int nrTests)
{
    Stopwatch swTotal = new Stopwatch();
    BigInteger averageTimeForLoops = new BigInteger(0);
    for (int i = 0; i < nrTests; i++)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        bool a = true;
        for(int j=0;j< nrTests; j++)
        {
            for(int k=0;k< nrTests; k++)
            {
                a = !a;
            }
        }
        sw.Stop();
        // add to the average the partial execution time
        averageTimeForLoops = BigInteger.Add(averageTimeForLoops, new BigInteger(sw.Elapsed.Ticks));
    }
}
```
This method has two clock, one for the actual number of cycles of execution of the algorithm, the other for the total miliseconds passed.
It will loop in loop for nrTests times and inverse the variable a and count the clock cycles.

##### BenchmarkSimpleOperations
```
private int BenchmarkSimpleOperations(int nrTests)
{
    long averageSimpleOperations = 0;
    do
    {
        averageSimpleOperations = 0;
        for (int times = 0; times < nrTests; times++)
        {
            long a = 0;
            for (int i = 0; i < nrTests; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                a = a + 1;
                sw.Stop();
                averageSimpleOperations += sw.ElapsedTicks;
            }
            for (int i = 0; i < nrTests; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                a = a - 1;
                sw.Stop();
                averageSimpleOperations += sw.ElapsedTicks;
            }
        }

    } while (averageSimpleOperations <= (nrTests * nrTests * 2)); // to make sure that a valid number is returned
}
```
This method has two clock, one for the actual number of cycles of execution of the algorithm, the other for the total miliseconds passed.
It will count the add operation, then the substraction operation to return the number of clock cycles needed to perform such operation.

### RAM Benchmark
### Storage Benchmark
### Microsoft Defined Data Structures Integration
### GUI
## Service
<div style="page-break-after: always;"></div>

# Testing and validation

## CPU Benchmark

In order to test the efficiency of the algorithm, a batch of unit tests were created. They test the results of the two public methods from the CPU class in the following manner:
```
[Test]
public void OneMIPSTest()
{

    float cpuMIPSValue = cpu.RunMIPSTests();
    Assert.IsTrue(cpuMIPSValue > 3); // This value was chosen looking at the Task Manager of the developing machine
}
[Test]
public void OneSimpleOperationsTest()
{
    float cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
    Assert.IsTrue(cpuSimpleOperationsValue < 5);
}
```
Looking at the Task Manager on the machine, it can be seen that when it runs on a specific CPU processor, there is a 100% spike in its activity.
![](https://github.com/tavisit/PC_Benchmark/blob/main/Resources/CPU_Usage.png?raw=true)
<div style="page-break-after: always;"></div>

# Conclusions

<div style="page-break-after: always;"></div>

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
15. [General Microsoft Information](https://docs.microsoft.com/en-us/dotnet/api/?view=net-5.0)
16. [Sha 256](https://www.n-able.com/blog/sha-256-encryption)
17. [Microsoft Computer System Hardware Classes](https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/computer-system-hardware-classes)
