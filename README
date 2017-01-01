# Wheel Of Fortune (Sega CD) Puzzle Editor

`WoFEditor` is a simple program that let's you edit the Sega CD Editon of Wheel Of Fortune to add your own prompts and categories. 

[![Editor](http://i.imgur.com/Xzt5ajx.png)](http://i.imgur.com/Xzt5ajx.png)

[![Editor](http://i.imgur.com/0394Ybq.png)](http://i.imgur.com/0394Ybq.png)

Now, some people reading this may be asking themselves "Why would anyone possibly want to edit the Sega CD Edition of Wheel of Fortune to add new prompts? This seems like a waste of time." Well, mystery person, yeah, I agree.

This program edits the `WHEELS.DAT` file, which contains all of the prompts and categories. Each one is given 68 bytes; the first 48 for the prompt, the last 20 for the category (And of which there is a buffer of two bytes after the game prompt). Spaces are used to format what gets shown on screen and where. Special characters like `&` and `'` will appear filled in. 

You can edit any of the existing prompts, click save, and export the whole new database file in from the `file` menu. For testing you can also use `Save Test File`, which will create a new database file with _just_ that prompt. After saving the database file, just replace `WHEELS.DAT` on the CD Image with the new one.