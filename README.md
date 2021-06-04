# Unity Utilities
A series of helpers, extension methods, and utilities I use in every project.

**How to use:**<br/>
To use, download zip or clone the repo, and place the files anywhere within your Unity project.

A number of these utilities are extension methods, so you can call them in 2 ways: (Using `ColorUtils.ChangeAlpha` as an example)
<br/>
1. Direct Use:
```cs
 Color colorWithAdjustedAlpha = ColorUtils.ChangeAlpha(originalColor, 0.5f);
```
2. Use as a exntension method:
```cs
 Color colorWithAdjustedAlpha = originalColor.ChangeAlpha(0.5f);
```

<br/>

Minimum Unity Version: `Unity 5.2`

---

**Note:**<br/>
This is a bit of a mixed bag of random lightweight methods, but I've tried to keep it organised.

Usually I have more in here, including serialisation helpers, etc., but I've tried to make it more light and generic, excluding more project specific stuff.

I may add to it in the future.

---

[Check out my other work][github]

[![Follow me on Twitter](https://img.shields.io/twitter/follow/loken01?color=1DA1F2&logo=twitter&style=for-the-badge)][twitter]

[twitter]: https://twitter.com/loken01
[github]: https://github.com/Loken01
