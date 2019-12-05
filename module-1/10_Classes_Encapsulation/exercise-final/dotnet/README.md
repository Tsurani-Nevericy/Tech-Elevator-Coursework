# Encapsulation

The purpose of this exercise is to provide you the opportunity to practice writing code that is extendable, maintainable, and loosely coupled through the art of encapsulation.

## Learning Objectives

After completing this exercise, students will understand:

* How to write code that is [loosely coupled][loose-coupling].
* How to write code that appropriately hides the internal details of classes.
* How to create readonly properties.
* How to limit access to properties through the use of [access modifiers][dot-net-access-modifiers].
* How to write [derived properties][derived-properties].

## Evaluation Criteria & Functional Requirements

* The project must not have any build errors.
* Unit tests pass as expected.
* Appropriate variable names and data types are being used.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* The code meets the specifications defined below.

**Notes for All Classes**
- X in the set column indicates it **should have a `set` accessor**.
- Nothing in the set column indicates the property is a [derived property][derived-properties].
- Readonly properties do not require a `set` accessor.
- Private setters require the property to have `private set`.

### HomeworkAssignment

#### Properties

| Property      | Data Type | Get | Set      | Description                                                                          |
| ------------- | --------- | --- | -------- | -------------------------------------------------------------------------------------|
| EarnedMarks   | int       | X   | X        | Gets or sets the total number of correct marks submitter received on the assignment. |
| PossibleMarks | int       | X   | readonly | Gets the number of possible marks on the assignment.                                 |
| SubmitterName | string    | X   | readonly | Gets or sets the submitter's name for the assignment.                                |
| LetterGrade   | string    | X   |          | Gets the letter grade for the assignment.                                            |

**Notes**

- `PossibleMarks` and `SubmitterName` are readonly properties that can only be set from the constructor.

- `LetterGrade` is a derived property that is calculated using EarnedMarks and possibleMarks.
  - For 90% or greater return "A"
  - 80-89% return "B"
  - 70-79% return "C"
  - 60-69% return "D"
  - otherwise return "F"
  - _hint_: PossibleMarks and EarnedMarks are integers. What happens when a smaller integer is divided by a larger integer?

#### Constructor

The `HomeworkAssignment` class has a single constructor. It accepts two arguments `possibleMarks` and `submitterName`.

`public HomeworkAssignment(int possibleMarks, string submitterName)`

### FruitTree

#### Properties

| Property          | Data Type | Get | Set      | Description                                            |
| ----------------- | --------- | --- | -------- | ------------------------------------------------------ |
| TypeOfFruit       | string    | X   | readonly | Gets the type of fruit on the tree.                    |
| PiecesOfFruitLeft | int       | X   | private  | Gets the number of remaining fruit pieces on the tree. |

**Notes**

N/A

#### Methods

`public bool PickFruit(int numberOfPiecesToRemove)`

**Notes**

- `PickFruit(int numberOfPiecesToRemove)` is a method
  - If there are enough pieces on the tree, "picks" the fruit and updates `PiecesOfFruitLeft` by substracting `numberOfPiecesToRemove` from it.
  - Returns `true` if successful (there were enough pieces to pick) or `false` if no fruit was picked (`PiecesOfFruitLeft` was less than `numberOfPiecesToRemove`).

#### Constructor

The `FruitTree` class has a single constructor. It accepts two arguments `typeOfFruit` and `startingPiecesOfFruit`.

`public FruitTree(string typeOfFruit, int startingPiecesOfFruit)`

### Employee

#### Properties

| Property     | Data Type | Get | Set      | Description                             |
| ------------ | --------- | --- | -------- | --------------------------------------- |
| EmployeeId   | int       | X   | readonly | Gets the employee id.                   |
| FirstName    | string    | X   | readonly | Gets the employee's first name.         |
| LastName     | string    | X   | X        | Gets or sets the employee's last name.  |
| FullName     | string    | X   |          | Gets the employee's full name.          |
| Department   | string    | X   | X        | Gets or sets the employee's department. |
| AnnualSalary | double    | X   | private  | Gets the employee's annual salary.      |

**Notes**

- `FullName` is a derived property that returns `LastName, FirstName`.

#### Methods

`public void RaiseSalary(double percent)`

**Notes**

- `RaiseSalary(double percent)` increases the current annual salary by the percentage provided (e.g. 5.5 represents 5.5%)

#### Constructor

The `Employee` class has a single constructor. It accepts four arguments.

`public Employee(int employeeId, string firstName, string lastName, double salary)`

### Airplane

#### Properties

| Property                 | Data Type | Get | Set      | Description                                         |
| ------------------------ | --------- | --- | -------- | --------------------------------------------------- |
| PlaneNumber              | string    | X   | readonly | Gets the six-character plane number.                |
| BookedFirstClassSeats    | int       | X   | private  | Gets the number of already booked first class seats |
| AvailableFirstClassSeats | int       | X   |          | Gets the number of available first class seats.     |
| TotalFirstClassSeats     | int       | X   | readonly | Gets the number of total first class seats.         |
| BookedCoachSeats         | int       | X   | private  | Gets the number of already booked coach seats       |
| AvailableCoachSeats      | int       | X   |          | Gets the number of available coach seats.           |
| TotalCoachSeats          | int       | X   | readonly | Gets the number of total coach seats.               |

**Notes**

- `AvailableFirstClassSeats` is a derived property calculated by subtracting `BookedFirstClassSeats` from `TotalFirstClassSeats`
- `AvailableCoachSeats` is a derived property calculated by subtracting `BookedCoachSeats` from `TotalCoachSeats`

#### Constructors

The `Airplane` class has a single constructor. It accepts two arguments.

    `Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)`

- `planeNumber` is the assigned plane number to the airplane.
- `totalFirstClassSeats` is the initial number of total first class seats.
- `totalCoachSeats` is the initial number of total coach seats.

#### Methods

`bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)`

**Notes**

- `ReserveSeats()` is a method
  - if forFirstClass is true, add `totalNumberOfSeats` to the value for `BookedFirstClassSeats`
  - if forFirstClass is false, add `totalNumberOfSeats` to the value for `BookedCoachSeats`
  - return `true` if there were enough seats to make the reservation

### Television

#### Properties

| Property       | Data Type | Get | Set     | Description                                                                 |
| -------------- | --------- | --- | ------- | --------------------------------------------------------------------------- |
| IsOn           | bool      | X   | private | Gets whether or not the TV is turned on.                                    |
| CurrentChannel | int       | X   | private | Gets the value for the current channel. Channel levels go between 3 and 18. |
| CurrentVolume  | int       | X   | private | Gets the current volume level.                                              |

#### Constructors

The `Television` class does not need a constructor. It can use the **default constructor**.

A new TV is off by default. The channel is set to 3 and the volume level to 2.

#### Methods

```
    void TurnOff()
    void TurnOn()
    void ChangeChannel(int newChannel)
    void ChannelUp()
    void ChannelDown()
    void RaiseVolume()
    void LowerVolume()
```

**Notes**

- `TurnOff()` turns off the tv
- `TurnOn()` besides turning the tv on, also resets the channel to 3 and the volume level to 2
- `ChangeChannel(int newChannel)` changes the current channel (only if it is on) to the value of `newChannel` as long as it is between 3 and 18
- `ChannelUp()` increases the current channel by 1 (only if it is on). If the value goes past 18, then the current channel should be set to 3.
- `ChannelDown()` decreases the current channel by 1 (only if it is on). If the value goes below 3, then the current channel should be set to 18.
- `RaiseVolume()` inceases the volume by 1 (only if it is on). The limit is 10
- `LowerVolume()` decreases the volume by 1 (only if it is on). The limit is 0

### Elevator

#### Properties

| Property       | Data Type | Get | Set      | Description                                          |
| -------------- | --------- | --- | -------- | ---------------------------------------------------- |
| CurrentLevel   | int       | X   | private  | Gets the current floor that the elevator is on.      |
| NumberOfLevels | int       | X   | readonly | Gets the number of levels available to the elevator. |
| DoorIsOpen     | bool      | X   | private  | Gets if the elevator door is open or not.            |

#### Constructor

The `Elevator` class has a single constructor that takes one argument. New elevators start on floor 1.

`Elevator(int numberOfLevels)`

- `numberOfLevels` indicates how many floors are available to the elevator

#### Methods

```
    void OpenDoor()
    void CloseDoor()
    void GoUp(int desiredFloor)
    void GoDown(int desiredFloor)
```

**Notes**

- `OpenDoor()` opens the elevator door.
- `CloseDoor()` closes the elevator door.
- `GoUp(int desiredFloor)` sends the elevator upward to the desired floor as long as the door is not open. Cannot go past last floor.
- `GoDown(int desiredFloor)` sends the elevator downward to the desired floor as long as the door is not open. Cannot go past floor 1.

## Getting Started

* Open the oop-with-encapsulation-exercises.sln solution in Visual Studio.
* Click on the **Test -> Run -> All Tests** Menu
* Click on the **Test Explorer** tab to see the results of your tests and which passed / failed.
* Provide enough code to get a test passing.
* Repeat until all tests are passing.

## Tips and Tricks

* **Note, If you find yourself stuck on a problem for longer than fifteen minutes, move onto the next, and try again later.**
* In this exercise, you will be creating the classes specified in the requirements section of this document. The unit tests you run will verify if you have defined the classes correctly. As you work on creating the classes, be sure to run the tests, and then provide enough code to pass the test. For instance, if you are working on the HomeworkAssignment class, provide enough code to get one of the HomeworkAssignment tests passing. By focusing on getting a single test to pass at a time, you will save yourself a lot of time, as this forces you to only focus on what is important for the test you are currently working on. This is commonly referred to as **[Test Driven Development][introduction-to-test-driven-development]**, or **TDD**.
* Be mindful of your [access modifiers][dot-net-access-modifiers].
* Keep in mind, a **loosely coupled** system is one in which each of its components has, or makes use of, little or no knowledge of the definitions of other separate components. One of your goals as a developer should be to write code that is loosely coupled.

---

[derived-properties]: https://www.uml-diagrams.org/derived-property.html
[dot-net-access-modifiers]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
[introduction-to-test-driven-development]: http://agiledata.org/essays/tdd.html
[loose-coupling]: http://wiki.c2.com/?CouplingAndCohesion
