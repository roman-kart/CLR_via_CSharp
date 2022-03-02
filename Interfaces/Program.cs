using Interfaces;

TestInterface TestInterface = new TestInterface();
Console.WriteLine("TestInterface: ");
TestInterface.VirtualSealed();
TestInterface.VirtualNonSealed();
Console.WriteLine();

Console.WriteLine("ITestVirtualMethods: ");
ITestVirtualMethods testVirtualMethods = new TestInterface();
testVirtualMethods.VirtualSealed();
testVirtualMethods.VirtualNonSealed();