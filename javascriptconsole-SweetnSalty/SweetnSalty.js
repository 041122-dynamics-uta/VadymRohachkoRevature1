//global vars
//count sweet
var sweet = 0;
//count salty
var salty = 0;
//count sweetnsalty
var sweetSalty = 0;
//compose string of words
var strOfWords = "";

//iteration in `for` loop
//start from 1 to 1000 including
for (let index = 1; index <= 1000; index++) {
  //if multiples of three and five
  if (index % 3 === 0 && index % 5 === 0) {
    //concatenate " SweetnSalty" to the string
    strOfWords = strOfWords.concat(" SweetnSalty");
    //increase counter by one
    ++sweetSalty;
  } else if (index % 3 === 0) {
    //concatenate " Sweet" to the string
    strOfWords = strOfWords.concat(" Sweet");
    //increase counter by one
    ++sweet;
  } else if (index % 5 === 0) {
    //concatenate " Salty" to the string
    strOfWords = strOfWords.concat(" Salty");
  } else {
    //concatenate number to the string
    strOfWords = `${strOfWords} ${index}`;
    //increase counter by one
    ++salty;
  }

  //when index = 20, stop concatenating and make a new line
  //make counter strOfWords ready for the next line
  if (index % 20 === 0) {
    console.log(strOfWords);
    strOfWords = "";
  }
}

//print total numbers
console.log(`\nSweetnSalty ${sweetSalty}`);
console.log(`Sweet ${sweet}`);
console.log(`Salty ${salty}`);
