#!/bin/bash

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
	echo "Hello!"
}

displayMathChoice() {
	echo -e "Please, choose an option:"
	echo "Add      - 1"
	echo "Subtract - 2"
	echo "Multiply - 3"
	echo "Divide   - 4"
	echo "Exit     - any key"
}

readChoiceMathOperation() {
	read typeOfMathOperation
}

displayUserCoice() {
	case $typeOfMathOperation in
	1) echo -e "You chose Add" ;;
	2) echo -e "You chose Subtract" ;;
	3) echo -e "You chose Multiply" ;;
	4) echo -e "You chose Divide" ;;
	*)
		clearScreen
		exitScript
		;;
	esac
}

getFirstInt() {
	echo -e "Enter the first integer"
	read firstInteger

	while ! [[ $firstInteger =~ ^[-]?[0-9]+$ ]]; do
		echo -e "\nWrong input. Only integers allowed. Try again..."
		read firstInteger
	done
}

getSecondInt() {
	echo -e "Enter the second integer"
	read secondInteger

	while ! [[ $secondInteger =~ ^[-]?[0-9]+$ ]]; do
		echo -e "\nWrong input.  Only integers allowed. Try again..."
		read secondInteger
	done

	if [[ $typeOfMathOperation == 4 && $secondInteger == 0 ]]; then
		echo -e "\nWrong input: the divider can not be 0."
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
	echo "Result of math operation is $result"
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
	result=$(awk "BEGIN {printf \"%.3f\",${firstInteger}/${secondInteger}}")
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
	displayMathResult
	readContinueOrQuit
	exacContinueOrQuit
}

clearScreen
greetUser
startNewGame
