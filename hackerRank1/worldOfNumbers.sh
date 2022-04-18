#!/bin/bash

read firstVar
while [[ $firstVar -lt -100 || $firstVar -gt 100 ]]; do
	read firstVar
done

read secondVar
while [[ ($secondVar -lt -100 || $secondVar -gt 100) || $secondVar = 0 ]]; do
	read secondVar
done

echo $((firstVar + secondVar))
echo $((firstVar - secondVar))
echo $((firstVar * secondVar))
echo $((firstVar / secondVar))
