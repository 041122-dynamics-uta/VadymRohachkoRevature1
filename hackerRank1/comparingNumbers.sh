#!/bin/bash

read firstVar
while ! [[ "$firstVar" =~ ^[-]?[0-9]+$ ]]; do
	read firstVar
done

read secondVar
while ! [[ "$secondVar" =~ ^[-]?[0-9]+$ ]]; do
	read secondVar
done

if [[ $firstVar -lt $secondVar ]]; then
	echo "X is less than Y"
elif [[ $firstVar -gt $secondVar ]]; then
	echo "X is greater than Y"
else
	echo "X is equal to Y"
fi
