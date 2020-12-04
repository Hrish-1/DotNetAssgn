using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Employee1
{

    bool[] arr = new bool[2];
    public bool[] IsValid
    {
        set { arr[0] = false; arr[1] = false; }
        get { return arr; }
    }
    public static int empCount
    {
        set;
        get;
    }
    private string name;
    public string Name 
    {
        set { if (value.Trim() == "") { Console.WriteLine("Invalid Name"); }
            else {  name = value; arr[0] = true; }
            }
        get { return name; }
    }
    public int empNo
    {
        set;
        get;
    }
    private short deptNo;
    public short DeptNo 
    {
        set { if (value > 0) { deptNo = value;  arr[1] = true; }
            else { Console.WriteLine("Invalid deptNo"); }
            }
        get { return deptNo; }
    }
    public abstract decimal basic
    {
        set;
        get;
    }
    public abstract decimal CalcNetSalary();
    public override string ToString()
    {
        return "empNo : " + empNo + ", Name : " + Name + ", DeptNo : " + DeptNo + ", Basic : " + basic +
               ", Salary : "+ CalcNetSalary();
    }
}
class Manager : Employee1
{
    string designation { set; get; }

    public Manager() { }
    public Manager(string designation,string name = "John",decimal basic = 15000,short deptNo = 10)
    {
        empCount++;
        this.empNo = empCount;
        this.Name = name;
        this.basic = basic;
        this.DeptNo = deptNo;
        this.designation = designation;
    }

    public override decimal basic { get; set; }

    public override decimal CalcNetSalary()
    {
        return basic * 12;
    }
    public override string ToString()
    {
        return "empNo : " + empNo + ", Name : " + Name + ", DeptNo : " + DeptNo + ", Basic : " + basic +
               ", Salary : " + CalcNetSalary() + ", Designation : " + designation;
    }
}
class GeneralManager : Manager
{
    string perks { set; get; }
    public GeneralManager(string name = "John", decimal basic = 15000, short deptNo = 10,string perks = "vacation")
    {
        empCount++;
        this.empNo = empCount;
        this.Name = name;
        this.basic = basic;
        this.DeptNo = deptNo;
        this.perks = perks;
    }
    public override decimal basic { get; set; }
    public override decimal CalcNetSalary()
    {
        return basic * 12;
    }
    public override string ToString()
    {
        return "empNo : " + empNo + ", Name : " + Name + ", DeptNo : " + DeptNo + ", Basic : " + basic +
               ", Salary : " + CalcNetSalary() + ", perks : " + perks;
    }
}
class CEO : Employee1
{
    public CEO(string name = "Jack", decimal basic = 50000, short deptNo = 1)
    {
        empCount++;
        this.empNo = empCount;
        this.Name = name;
        this.basic = basic;
        this.DeptNo = deptNo;
    }
    public override decimal basic { get; set; }

    public override sealed decimal CalcNetSalary()
    {
        return basic * 12;
    }
}
class MainClass1
{
    static void Main(string[] args)
    {
        Employee1 e = new Manager("Automobile","Asher",20000,1);
        if(e.IsValid[0] && e.IsValid[1])
            Console.WriteLine(e);
        Employee1 e1 = new GeneralManager("", 20000, 0);
        if(e1.IsValid[0] && e1.IsValid[1])
            Console.WriteLine(e1);
        Employee1 e2 = new CEO("Joma",75000,1);
        if(e2.IsValid[0] && e2.IsValid[1])
            Console.WriteLine(e2);
    }
}

