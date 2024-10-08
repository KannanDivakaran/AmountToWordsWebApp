# ASP .Net core MVC project

A sample application with ASP .Net core MVC Web application.

# Set up
1. Create new ASP.NET Core Web application Project with name AountToWords
2. Select Web Application in template window and set Authentication to No Authentication and click OK.
3. Add view numberToWords.cshtml under pages
4. Add numer to words controller functions in HomeController.cs

# Capture the input from Web page.

<img width="957" alt="image" src="https://github.com/user-attachments/assets/d00f1ca1-9c1e-45e4-a25e-5e0eb06a1465">

# Add logics to split the number to beforedecimal and after decimal values
# Add common logic to convert the numbet to words
# Combine the words and display.

<img width="959" alt="image" src="https://github.com/user-attachments/assets/84b93723-743f-47f1-9f79-8dc3c4976eab">

# Why the framework this approach is selected.
A main advantage of MVC is its separation of concern. The separation of concern means we can divide the application Model, Control and View.
We can easily maintain our application because of separation of this.
In the same time we can split many developers work at a time. It  will not affects  one developer work to another developer work. 
It supports TTD (test-driven development). We can create an application with unit test. We can write won test case.
Latest version of MVC Support default responsive web site and mobile templates.
We can create own view engine. It is syntax is very easy compare to traditional view engine.

# If other framework like angular or React is slected then 
1. We have to integrate two independent applications for Web UI and the C# service.That will be complex in this particular case.
2.Then we need inetgration with a server and deploy the service and then consume the service from front end web application.
3.Code maintenance, testing and deployemnts are super easy with ASP.NET MVC frame work.
 
# Test Plan
1. Execute Amount between < 10.
   Expected outcome :Input: "10.23"
                     Output: "TEN DOLLARS and TWENTY-THREE CENTS"
3. Excute Amount between 10 -99
    Expected outcome : Input: "55.55"
                       Output: "FIFTY-FIVE DOLLARS and FIFTY-FIVE CENTS"
4. Excute Amount > 100
   Expected outcome :Input: "123.45"
                     Output: "ONE HUNDRED TWENTY-THREE DOLLARS and FORTY-FIVE CENTS"
5. A spacial case of Negative also can be tested
   Expected outcome : Input: "-23"
                     Output: "NEGATIVE TWENTY-THREE DOLLARS and ZERO CENTS"
6.An Amount without decimal
 Expected outcome :Input: "23"
                   Output: "TWENTY-THREE DOLLARS and ZERO CENTS"
7.A number with decimal only.
Expected outcome :Input: "0.45"
                  Output: "ZERO DOLLARS and FORTY-FIVE CENTS"
8. Aount 0 and all other inputs will return below output
 Expected outcome:  Input: "0"
                   Output: "ZERO DOLLARS and ZERO CENTS"
