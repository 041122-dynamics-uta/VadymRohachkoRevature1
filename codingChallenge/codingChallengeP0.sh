#!/bin/bash

#constants
mathOperations=('+' '-' 'x' '/')
#globals
typeOfMathOperation=0
firstInteger=0
secondInteger=0
userChoice=0
result=0

clearScreen() {
	clear
}

exitScript() {
	exit
}

clearGlobalVars() {
	typeOfMathOperation=0
	firstInteger=0
	secondInteger=0
	userChoice=0
}

greetUser() {
	echo -e "\nHello! May I know your name?"
	read userName
	echo -e "\nWelcome to Simple calculator, $userName!\n"
}

displayMathChoice() {
	echo "Please, choose an option:"
	echo "Add      - 1"
	echo "Subtract - 2"
	echo "Multiply - 3"
	echo "Divide   - 4"
	echo "Exit     - any key"
	echo ""
}

readChoiceMathOperation() {
	read typeOfMathOperation
}

displayUserCoice() {
	case $typeOfMathOperation in
	1) echo "You chose Add" ;;
	2) echo "You chose Subtract" ;;
	3) echo "You chose Multiply" ;;
	4) echo "You chose Divide" ;;
	*)
		clearScreen
		exitScript
		;;
	esac
}

getFirstInt() {
	echo "Enter the first integer"
	read firstInteger

	while ! [[ $firstInteger =~ ^[-]?[0-9]+$ ]]; do
		echo "Wrong input. Only integers allowed. Try again..."
		read firstInteger
	done
}

getSecondInt() {
	echo "Enter the second integer"
	read secondInteger

	while ! [[ $secondInteger =~ ^[-]?[0-9]+$ ]]; do
		echo "Wrong input.  Only integers allowed. Try again..."
		read secondInteger
	done

	if [[ $typeOfMathOperation == 4 && $secondInteger == 0 ]]; then
		echo "Wrong input: the divider can not be 0."
		getSecondInt
	fi
}

exacMathOperation() {
	case $typeOfMathOperation in
	1) addTwoInt ;;
	2) substractTwoInt ;;
	3) multiplyTwoInt ;;
	4) divideTwoInt ;;
	esac
}

displayMathResult() {
	echo "Result: $1 $2 $3 = $4"
}

readContinueOrQuit() {
	echo "Y(y) to continue, any other key to quit"
	read userChoice
}

exacContinueOrQuit() {
	if [[ $userChoice == "Y" || $userChoice == "y" ]]; then
		clearScreen
		startNewGame
	else
		clearScreen
		exitScript
	fi
}

addTwoInt() {
	((result = firstInteger + secondInteger))
}

substractTwoInt() {
	((result = firstInteger - secondInteger))
}

divideTwoInt() {
	result=$(awk "BEGIN {printf \"%.1f\",${firstInteger}/${secondInteger}}")
	if [[ $result == "1.0" ]]; then
		# sed 's/\.0$//     sed replaces 0 decimals with space
		# to display only number without zeroes
		# get value from $result and pipes it to sed expression and 
	        # then returns it to result again
		result=$(echo "$result" | sed 's/\.0$//')
	fi
}

multiplyTwoInt() {
	((result = firstInteger * secondInteger))
}

startNewGame() {
	clearGlobalVars
	displayMathChoice
	readChoiceMathOperation
	displayUserCoice
	getFirstInt
	getSecondInt
	exacMathOperation
	displayMathResult $firstInteger ${mathOperations[$typeOfMathOperation - 1]} $secondInteger $result
	readContinueOrQuit
	exacContinueOrQuit
}

clearScreen
greetUser
startNewGame
