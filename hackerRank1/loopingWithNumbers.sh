#!/bin/bash

for j in {1..50}; do
	if [[ $j > 0 ]]; then
		printf "$j\n"
	fi
done
