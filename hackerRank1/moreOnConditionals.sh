#!/bin/bash

read firstUserInput
read secondUserInput
read thirdUserInput

if [[ ! ($firstUserInput =~ ^[0-9]+$ ||
	$secondUserInput =~ ^[0-9]+$ ||
	$thirdUserInput =~ ^[0-9]+$) ||
	("$firstUserInput" -lt 1 || "$firstUserInput" -gt 1000) ||
	("$secondUserInput" -lt 1 || "$secondUserInput" -gt 1000) ||
	("$thirdUserInput" -lt 1 || "$thirdUserInput" -gt 1000) ]]; then
	exit
fi

if [[ $firstUserInput -eq $secondUserInput && $secondUserInput -eq $thirdUserInput ]]; then
	echo "EQUILATERAL"
elif [[ $firstUserInput -eq $secondUserInput || $secondUserInput -eq $thirdUserInput || $thirdUserInput -eq $firstUserInput ]]; then
	echo "ISOSCELES"
else
	echo "SCALENE"
fi
