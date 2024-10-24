﻿using AsyncAwaitExample;

Console.WriteLine("Hello, Async Await!");


Console.WriteLine("Starting payroll calculation...");

decimal hourlyRate = 50m;
int hoursWorked = 160;

SalaryCalculator calculator = new SalaryCalculator();

decimal grossSalary = calculator.CalculateGrossSalary(hourlyRate, hoursWorked);

decimal tax = calculator.CalculateTax(grossSalary);

Console.WriteLine($"Tax: {tax:C}");