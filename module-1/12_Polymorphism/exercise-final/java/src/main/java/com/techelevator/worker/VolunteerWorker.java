package com.techelevator.worker;

public class VolunteerWorker implements Worker {

    private double annualSalary;
    private String firstName;
    private String lastName;

    public VolunteerWorker(String firstName, String lastName) {
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

    public double calculateWeeklyPay(int hoursWorked) {
        return 0;
    }

}
