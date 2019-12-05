<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<!DOCTYPE html>
<html>
	<head>
		<title>Hello Spring MVC</title>
		<link rel="stylesheet" href="site.css"></link>
	</head>
	<body>
		<div id="main_content">
			<h1>Thanks, You're Awesome!</h1>
		</div>
		<div>
			<h3>Your Answers</h3>
			<div><strong>What is your favorite color? </strong> ${survey.color }</div>
			
			<div><strong>What is your quest? </strong> ${survey.natureOfQuest }</div>
			
			<div><strong>Do you prefer cats or dogs? </strong> ${survey.petPreference }</div>
			
			<div><strong>Email Address: </strong> ${survey.emailAddress }</div>
			
			<div><strong>Do you prefer C# or Java? </strong> ${survey.language }</div>
		
		</div>
	</body>
</html>