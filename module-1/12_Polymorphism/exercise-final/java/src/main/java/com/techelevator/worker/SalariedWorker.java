package com.techelevator.worker;

public class SalariedWorker implements Worker {

    private double annualSalary;
    private String firstName;
    private String lastName;

    public SalariedWorker(double annualSalary, String firstName, String lastName) {
        this.annualSalary = annualSalary;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public double getAnnualSalary() {
        return annualSalary;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    /*
    * Weekly pay for salary worker is annual pay over 52 weeks
    */
    @Override
    public double calculateWeeklyPay(int hoursWorked) {
        return this.annualSalary / 52;
    }

}
