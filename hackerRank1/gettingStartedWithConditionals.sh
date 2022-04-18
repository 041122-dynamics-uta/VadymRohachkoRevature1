#!/bin/bash

localFlag=0

read userInput
while [[ $localFlag != 1 ]]; do
	case $userInput in
	y | Y)
		echo -n "YES"
		localFlag=1
		;;
	n | N)
		echo -n "NO"
		localFlag=1
		;;
	*)
		read userInput
		;;

	esac
done
