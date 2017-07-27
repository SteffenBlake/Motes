#Join the team 
 Do you want to collaborate? Join the project at https://projectgroupie.com/projects/203

## Motes 😎
Motes is a new Emoji based programming language, designed for simplicity and fun! If you've ever been interested in learning to program, or are a experienced programmer looking for a fun new way to mess around, then Motes is for you!

### Get Started! 😄

Step 1: Make sure you have your .net libraries up to date on your computer, you can download them from microsoft at the link below:

[.NET 4.5](https://www.microsoft.com/en-ca/download/details.aspx?id=30653)

Step 2: Grab your latest install zip of Motes from the link below!

Step 3: Unzip the folder to a spot wherever you please, then open it and run Installer.exe located within. This will setup your version of Motes and get everything ready.

[Latest Release V1.0.2.0 x64](https://github.com/SteffenBlake/Motes/releases/download/1.0.3.0/Motes.v1.0.3.0.x64.zip)

[Latest Release V1.0.2.0 x86](https://github.com/SteffenBlake/Motes/releases/download/1.0.3.0/Motes.v1.0.3.0.x86.zip)

If you need an unzip software, [Winrar](http://www.rarlab.com/download.htm) is very popular

Step 4: Make sure you restart your computer for the changes to apply!

Step 5: Download your choice of editor. It needs to be capable of handling emoji! [Visual Studio Code](https://code.visualstudio.com/) works quite well!

Step 6: Create a .mot file anywhere you like on your computer and put some code in it (keep reading to learn how it works!)

Step 7: Save it as a .mot (important), then go to where you saved it and run the .mot file (double clicking should do the job!)

It's that easy!

## How to Program 👌

Motes supports a wide range of Emoji, but first and foremost you should know that any non-emoji you put in the document won't hurt anything. You can add spaces and even new lines and the interpretter won't notice a difference. Have at it!

The first thing to understand is Motes has no form of variables. Instead you have whats called the **Index**, which is an infinitely long list of numbers you can edit. You start with your **Pointer** (👆) pointing to the very first number in the list. You can move your **Pointer** left and right on the **Index**, and you can increase and decrease values of the **Index** you are pointing at.

Second you have two pieces of **Memory**, these are called the **Reader** and the **Function**, but you can just remember them as their emoji values, 📖 and 🌀

Whats the difference? Well you can Read(📖) *and* Write(✍) to 💾, but you can *only* 📖 from 🌀. How do you change the value of 🌀? We'll get to that later!

Motes seperates Emoji into the following categories:

## Data 👓
These friends are a lot like your toolbox of Emoji. All the ones listed here let you change and modify the data you have. Saving, Reading, and Writing are all handled here!

### 👈/👉 : Move Pointer
These values move your Pointer left and right. They're two of your most important Emoji!

### 👍/👎 : Increase/Decrease
These friends will increases or decrease the value of your current index you are pointing at by 1. These two are also very important!

### 💩 : Reset
This silly little friend will set the value of your current pointed index to 0, no matter what it is!

### ✍ : Write
If you want to save something for later, this character will copy the value at your current index to Memory

### 📖 : Read
Reading is important! This value does the opposite of write, it takes whatever you have in Memory and copies it to your current pointed index!

### 🌀 : Function Read
This tricky fellow will do the same thing as 📖, except it reads from your **Function Memory**. To put something in there though you'll need to learn more about functions. We'll get to that in a bit down below!

### 🔃 : Swap
If you want to copy a value to Memory without losing what you had before, this little friend will switch places for your index and your Memory. So if you are pointing at a 5 and you have a 7 in memory, the two will switch places!

### 💦 : Flush
When you want to start from scratch, go for this tool! 💦 will reset your entire index, setting you back to the start *and* wipe all your values clean back to 0. This is important if you don't want old data to mess with other things!

### 🔚 : Return
This handy friend will make you point back to the very first index. So you can rest assured that no matter how lost you are, you can always use 🔚 to get back home safely!

### 🎲 : Random!
This one is funny, it will make your current index value a totally random number between 0 and 99! I wonder what kind of cool things you can do with that?

## I/O 💻
You will notice right away when you work with Motes that it has a window everything runs in to show you what's happening. Without them you could run your program, but you'd never see what is happening!

### 💯 : Print Number
This buddy will write the number value of your current index to the window. If you're pointed Index has a value of 42 for example, you will see a nice big '42' appear in the window!

### 💬 : Print Character
This is the other important writing Emoji. It will write the character version of your current pointed index. Not sure what that means? Every letter and character in computers has a number value, luckily our friends Unicode have made us a nice chart that lets you look up whatever value you need!

https://unicode-table.com/en/#0023

You can find the number you need by clicking the character and look at the HTML Code they give you. For example, 'A' is 65, and 'a' is 97. You can even print non-letter symbols like ♥ (9829)!

### ✋ : Pause
When the program hits this symbol it will pause what it is doing until you hit any key on your keyboard, then it will continue on as if nothing happened!

### 👌 : New Line
This Emoji will start a new line, because you'll quickly notice 💯 and 💬 will just keep printing on the same line unless you tell them otherwise (except for character 10, which is the new line character!)

In fact, 👌 is basically just 💬 but it only prints character 10. Handy!

### 💤 : Sleep
Sometimes it is nice to take a break! 💤 will make your program stop for a bit of time, specifically it stops for the amount of time you have currently saved in Memory in 10ths of seconds. For example, if you have a 35 stored in memory, 💤 will sleep for 3 and a half seconds! This is really useful if your program prints a lot of things out and you want it to slow down so you have enough time to read it!

### ♻ : Recycle
Recycling is important! Especially if your screen is cluttered. This useful tool will make your window wipe clean all nice and fresh for new things to print to it. This is nice if you want to keep things nice and tidy!

### 👻 : Comment
This is a neat trick! 👻 will make all code that comes after it on the same line get skipped. This is great if you want to disable code temporarily for testing, or if you want to write plain english comments to tell people reading your code what it does.

It should be noted that a second 👻 on the same line will re-enable code after it on that line. For example:

**\<This Code will work>**👻*\<This code won't!>*👻**\<This Code will work again!>**

👻*\<This part is a comment>*

**\<But on a newline code will start working again!>**👻*\<Unless you put another at the end!>*

## 🔗 Looping 🔗
Writing the same code over and over is not just boring, but inefficient! Loops let you do repetative tasks easily! If you've ever worked with BEDMAS and recall how Brackets worked, it's basically the same thing!
Whenever you hit the end point of a loop the program will check the value you have in your memory (📖). If its condition does not get satisfied, it will move back to the start of the loop and try again. Be careful, if you do not set your code up right you can get stuck in infinite loops!

### 🔗 : Chain
To start you will need a chain link, this sets the left side of your loop, it doesn't actually *do* anything, but you wil definitely need these if you want to make loops!

### ➕ : Positive Loop
When you hit this Emoji, you will exit the loop if the current value in Memory(📖) is **positive**. If not, you'll loop back to its 🔗

### ➖ : Negative Loop
When you hit this Emoji, you will exit the loop if the current value in Memory(📖) is **negative**. If not, you'll loop back to its 🔗

### ✔ : Equals Loop
When you hit this Emoji, you will exit the loop if the current value in Memory(📖) is **equal to zero**. If not, you'll loop back to its 🔗

### ✖ : Not Equals Loop
When you hit this Emoji, you will exit the loop if the current value in Memory(📖) is **not equal to zero**. If not, you'll loop back to its 🔗

About chains:
It should be noted you can nest chains, which means put them inside of each other. For example:


🔗\<Some code>🔗\<Some more code>➕➖

In this example, \<Some code> is an outer loop checking ➖, and <Some more code> will run as an inner loop checking ➕, neat, huh? You can also imagine it in your head like this:

(Some code(Some more code))

## Functions 😄

Finally for the most important part of Motes! If you find chunks of your code get used all the time, you can set them to a function and then call that code with just one character each time, so you only need to write it once!

Here's a list of all the Emoji you can bind to functions (You will probably notice a pattern ;)

# 😁 😂 😃 😄 😅 😆 😉 😊 😋 😎 😍 😘 😚 😐 😶 😏 😣 😥 😪 😫 😷
# 😌 😜 😝 😒 😓 😔 😲 😖 😞 😤 😢 😭 😨 😩 😰 😱 😳 😵 😡 😠 😇

To begin, start by declaring your function anywhere in your code. Most people will often put them at the end after your main code.

You declare the function using the symbol 💾 followed by a smiley face emoji. You then finish the function with the 👏.

For example, the following code will declare a 😎 function that prints out both the number and the character of your current pointed index:

# 💾😎💯👌💬👌👏

Then whenever you use 😎, it will do that chunk of code!

**Important: If you try and declare the same function twice, Motes will get mad at you and give you errors! Don't use the same one twice!**

Now you were probably wondering what the deal with 🌀 is, right? Here's where it gets interesting!

When you use a function, that code chunk gets its own temporary index, pointer, fresh memory, everything! It's like a program in your program. When it finishes, it'll look at the current value of *its* pointed index and *write that to the 🌀 of the program that ran it!*

Furthermore, the value of your current memory will get passed *into* the function and written to *its* first index before it starts, which can be very useful. If you want to avoid that, consider having a 💩 at the start of your function to get rid of it!

It should also be noted you can declare functions inside of functions, except for themselves. The reason is you can make functions call themselves. In programming we call this *recursion* and there are lots of cool tricks you can do with it. We won't cover that here but if you are curious, you can find lots of info on recursion all over the internet!

## Write your first program

So let's do a basic test program. Here's the code:

## 🔗👍✍😎➖

##💾😎💯👌💬👌✋👏

How does this work? Well first on the second line you can see we declared(💾) a function(😎) and told it to print(💯) it as a number, print(👌) a new line, print(💬) the value as a character, print(👌) another newline, and then pause(✋) for input. Finally we end(👏) the function.

Basically now whenever we call 😎, it will print out the number and the character every time.

As for the actual code at the top, what does that do?

Well we first start(🔗) a loop(➖) that will keep going until the value in memory is negative. You'll notice we never do a decrease(👎) here so it seems like this program will just loop forever.

Inside the program all we do is first increase(👍) the value of our index, then write(✍) it to memory. We then call 😎 which will of course print that value out as we asked it to. Then we loop back.

In other words, this program will loop through and print every character for you and its associated value. Useful! (Run it and see what happens when you print character 7, make sure your speaker is turned on)

If you have any questions, you can always email me at steffen.cole.blake@gmail.com


# Contributing to the repo
I hope you enjoyed this brief tutorial on Motes. If you'd like to join in on this open source project, feel free to jump right in! All submissions for pull requests must test to be fully working, and must not remove currently existing features unless explicitly explained and verified.


# Roadmap (reference for anyone looking to contribute)
## Version 2.0 goals (functionality update):
 ✔ Create installer system for x86/x64 versions (1.0)
 
 ➖ Properly designed recursion and inheritance for sub routines (1.1)
 
 ➖ Index/Mem/Func UI objects to show representations of the current state machine (1.2)
 
 ➖ Addition of 🙊 🙉 🙊 Emoji to handle debug/warning levels (1.3)
 
 ➖ Add ability to read user input as a number (⌨️) and as a raw string (👂) (1.4)
 
 
## Version 3.0 goals (Documentation update)
 ➖ Create wiki (2.0)
 
 ➖ Design page for each currently existing supported emoji (2.1)
 
 ➖ Automatically add latest version info to VersionHistory.txt (2.2)
 
 ➖ Create concrete documentation for branching and pull/update procedure (2.3)
 
 ➖ Impliment proper testing systems using NUnit (2.4)
 

## Version 4.0 goals (Bells and Whistles update)
 ➖ Impliment midi support (3.1) 🎼 🎹 🎷 🎺 🎸 🎻 🔔
 
 ➖ Add methods to change font color and other visual changes to output (3.2)
 
 ➖ Add ability to listen for keydown events (🎮) (3.3)
 
 ➖ Add ability to move the cursor to specific horizontal and vertical positions (3.4)
 
 
## Version 5.0 goals
 ➖ ???
