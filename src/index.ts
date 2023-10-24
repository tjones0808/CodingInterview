// write a function that returns the reverse of a string
// reverse('abc') === 'cba'
// reverse('hello') === 'olleh'

// Solution #1
function reverse(str: string): string {
	return str.split("").reverse().join("");
}

// Solution #2
function reverse2(str: string): string {
	let reversed = "";
	for (let char of str) {
		reversed = char + reversed;
	}
	return reversed;
}

// Solution #3
function reverse3(str: string): string {
	return str.split("").reduce((reversed, char) => char + reversed, "");
}

console.log(reverse("abc"));
console.log(reverse2("abc"));
console.log(reverse3("abc"));

// write a function that returns the longest word in the sentence

// Solution #1
function longestWord(str: string): string {
	const words = str.split(" ");
	let longest = "";
	for (let word of words) {
		if (word.length > longest.length) {
			longest = word;
		}
	}
	return longest;
}

// Solution #2
function longestWord2(str: string): string {
	return str.split(" ").reduce((longest, word) => (word.length > longest.length ? word : longest), "");
}

console.log(longestWord("hello world master"));
console.log(longestWord2("hello world master exponetial"));

// write a function that checks whether a given string is a palindrome or not (reads the same forward and backward)

// Solution #1
function isPalindrome(str: string): boolean {
	return str.split("").reverse().join("") === str;
}

// Solution #2
function isPalindrome2(str: string): boolean {
	return str.split("").every((char, index) => char === str[str.length - index - 1]);
}

console.log(isPalindrome("abba"));
console.log(isPalindrome2("racecar"));

// write a function to remove duplicate elements from an array and explain solution and time complexity

// Solution #1
// Explanation: This function uses the filter() method to create a new array. For each element in the array, it checks if the current index is the first occurrence of the item using indexOf(). If it is, the item is included in the result.

// Time Complexity: O(n^2) For each element in the array, the indexOf() method scans the array, resulting in quadratic time complexity.
function removeDuplicates(arr: number[]): number[] {
	// The filter() method creates a new array with all elements that pass the test implemented by the provided function.
	return arr.filter(
		(item, index) =>
			// For each element, it checks if the current index is the first occurrence of the item in the array.
			arr.indexOf(item) === index
	);
}

// Solution #2
function removeDuplicates2(arr: number[]): number[] {
	const result: number[] = [];
	for (let item of arr) {
		// If the item is not already in the result array, add it.
		if (!result.includes(item)) {
			result.push(item);
		}
	}
	return result;
}

// Solution #3
function removeDuplicates3(arr: number[]): number[] {
	const result: number[] = [];
	const map: { [key: string]: boolean } = {};
	for (let item of arr) {
		// If the item has not been seen before, add it to the result array and mark it as seen in the map.
		if (!map[item]) {
			result.push(item);
			map[item] = true;
		}
	}
	return result;
}

// Solution #4
function removeDuplicates4(arr: number[]): number[] {
	// The Set object lets you store unique values of any type. Converting the array to a set automatically removes duplicates.
	return [...new Set(arr)];
}

console.log(removeDuplicates([1, 2, 3, 1, 2, 3, 4]));
console.log(removeDuplicates2([1, 2, 3, 1, 2, 3, 4]));
console.log(removeDuplicates3([1, 2, 3, 1, 2, 3, 4]));
console.log(removeDuplicates4([1, 2, 3, 1, 2, 3, 4]));

// write a function that checks whether two strings are anagrams or not (contain the same characters)

// Solution #1
function isAnagram(str1: string, str2: string): boolean {
	return str1.split("").sort().join("") === str2.split("").sort().join("");
}

// Solution #2
function isAnagram2(str1: string, str2: string): boolean {
	const map1 = buildCharMap(str1);
	const map2 = buildCharMap(str2);
	if (Object.keys(map1).length !== Object.keys(map2).length) {
		return false;
	}
	for (let char in map1) {
		if (map1[char] !== map2[char]) {
			return false;
		}
	}
	return true;
}

function buildCharMap(str: string): { [key: string]: number } {
	const map: { [key: string]: number } = {};
	for (let char of str) {
		map[char] = map[char] + 1 || 1;
	}
	return map;
}

console.log(isAnagram("listen", "silent"));
console.log(isAnagram2("abc", "cba"));

// write a function that returns the number of vowels in a string

// Solution #1
function countVowels(str: string): number {
	const matches = str.match(/[aeiou]/gi);
	return matches ? matches.length : 0;
}

// Solution #2
function countVowels2(str: string): number {
	let count = 0;
	const vowels = ["a", "e", "i", "o", "u"];
	for (let char of str) {
		if (vowels.includes(char)) {
			count++;
		}
	}
	return count;
}

console.log(countVowels("hello"));
console.log(countVowels2("hello"));

// write a function to find the largest number in an array

// Solution #1
function max(arr: number[]): number {
	return Math.max(...arr);
}

// Solution #2
function max2(arr: number[]): number {
	let max = arr[0];
	for (let num of arr) {
		if (num > max) {
			max = num;
		}
	}
	return max;
}

console.log(max([1, 2, 3, 4, 5]));
console.log(max2([1, 2, 3, 4, 5]));

// write a function to check if a given number is a prime number

// Solution #1
function isPrime(num: number): boolean {
	if (num <= 1) {
		return false;
	}
	for (let i = 2; i < num; i++) {
		// If the number is divisible by any number other than 1 and itself, it is not prime.
		if (num % i === 0) {
			return false;
		}
	}
	return true;
}

// Solution #2
function isPrime2(num: number): boolean {
	if (num <= 1) {
		return false;
	}
	// If the number is divisible by any number other than 1 and itself, it is not prime.
	for (let i = 2; i <= Math.sqrt(num); i++) {
		if (num % i === 0) {
			return false;
		}
	}
	return true;
}

console.log(isPrime(7));
console.log(isPrime2(10));

// write a function to calculate the factorial of a number ( 5! = 5 * 4 * 3 * 2 * 1)

// Solution #1
function factorial(num: number): number {
	let result = 1;
	for (let i = 2; i <= num; i++) {
		result *= i;
	}
	return result;
}

// Solution #2
function factorial2(num: number): number {
	if (num <= 1) {
		return 1;
	}
	return num * factorial2(num - 1);
}

console.log(factorial(5));
console.log(factorial2(5));

// write a function to remove all whitespace characters from a string

// Solution #1
function removeWhitespace(str: string): string {
	return str.replace(/\s/g, "");
}

// Solution #2
function removeWhitespace2(str: string): string {
	return str.split(" ").join("");
}

// Solution #3
function removeWhitespace3(str: string): string {
	return str
		.split("")
		.filter((char) => char !== " ")
		.join("");
}

console.log(removeWhitespace("hello world"));
console.log(removeWhitespace2("hello world"));
console.log(removeWhitespace3("hello world"));

// Define the decorator function
function splitString(target: Object, propertyKey: string, descriptor: PropertyDescriptor): PropertyDescriptor {
	const originalMethod = descriptor.value; // Save a reference to the original method

	descriptor.value = function (...args: any[]) {
		const result = originalMethod.apply(this, args); // Call the original method so that we can retain the same scope and arguments
		return result.split(""); // Split the string and return the result
	};

	return descriptor; // Return the updated descriptor
}

// write a reverse decorator update
function _reverse(target: Object, propertyKey: string, descriptor: PropertyDescriptor): PropertyDescriptor {
	const originalMethod = descriptor.value; // Save a reference to the original method

	descriptor.value = function (...args: any[]) {
		const result = originalMethod.apply(this, args); // Call the original method so that we can retain the same scope and arguments
		return result.split("").reverse().join(""); // Split the string and return the result
	};

	return descriptor; // Return the updated descriptor
}

class StringSplitter {
	@splitString
	@_reverse
	getString(str: string): string {
		return str;
	}
}

const splitter = new StringSplitter();
console.log(splitter.getString("hello")); // Output: ['h', 'e', 'l', 'l', 'o']
