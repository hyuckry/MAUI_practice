https://github.com/rogerwcpt/xamarin-mvvvm-frameworks

# A Comparison Matrix of MVVM Frameworks for Xamarin

I often see the question in forums "Which is the best MVVM Framework for Xamarin that I should use?" or "Should I use an MVVM Framework for Xamarin?".

To answer this question for myself (and others hopefully), I've done some research and compared the popular MVVM frameworks for Xamarin and elaborated what they have over the vanilla out the box Xamarin Forms (and Xamarin Native) offfering.

>(Comparison below is based on stable versions, not pre-release)

|Feature|MVVMCross|FreshMVVM|Prism.Forms|MVVMLight|Caliburn.Micro|
|-------|---------|---------|-----------|---------|------------|
|Supports Xamarin Forms|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|Supports Xamarin Native|:white_check_mark:|:no_entry:|:no_entry:|:white_check_mark:|:no_entry:|
|Active Development|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|Up to date Samples|:white_check_mark:|:white_check_mark:|:white_check_mark:|:no_entry:|:white_check_mark:|
|.NET Foundation Member|:white_check_mark:|:no_entry:|:white_check_mark:|:no_entry:|:no_entry:|
|.NET Standard Support|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:no_entry:|
|Up to date documentation|:white_check_mark:|:white_check_mark:|:no_entry:|:no_entry:|:no_entry:|
|Built in IOC Container|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|Fast IOC Container|:white_check_mark:|:white_check_mark:|:no_entry:|:white_check_mark:|:white_check_mark:|
|View-to-ViewModel auto wiring|:white_check_mark:|:white_check_mark:|:white_check_mark:|:no_entry:|:white_check_mark:|
|Navigation Service|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|ViewModel-to-ViewModel Navigation|:white_check_mark:|:white_check_mark:|:no_entry:|:no_entry:|:white_check_mark:|
|ViewModel Parameters|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|ViewModel Lifecycle|:white_check_mark:|:white_check_mark:|:no_entry:|:no_entry:|:white_check_mark:|    
|Non-Invasive XAML|:no_entry:|:white_check_mark:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|Event Aggregator|:white_check_mark:|:no_entry:|:white_check_mark:|:white_check_mark:|:white_check_mark:|
|View Presenter Overriding|:white_check_mark:|:no_entry:|:no_entry:|:no_entry:|:no_entry:|
|Converter Helpers|:white_check_mark:|:no_entry:|:no_entry:|:no_entry:|:no_entry:|
|Plugin Support|:white_check_mark:|:no_entry:|:white_check_mark:|:no_entry:|:no_entry:|
|Switch IOC Container|:white_check_mark:|:no_entry:|:white_check_mark:|:white_check_mark:|:white_check_mark:|


## GitHub Stats

|Links|MVVMCross|FreshMVVM|Prism.Forms|MVVMLight|Caliburn.Micro|
|-----|---------|---------|-----------|---------|---------|
|GitHub|[Link](https://github.com/MvvmCross/MvvmCross)|[Link](https://github.com/rid00z/FreshMvvm)|[Link](https://github.com/PrismLibrary/Prism)|[Link](https://github.com/lbugnion/mvvmlight)|[Link](https://github.com/caliburn-micro/caliburn.micro)|
|GitHub master Last commit*|1 month ago|9 days ago|11 days ago|3 months ago|1 month ago|
|Contributors|275|15|83|4|34|


## Nuget Stats
|Links|MVVMCross|FreshMVVM|Prism.Forms|MVVMLight|Caliburn.Micro|
|-----|---------|---------|-----------|---------|---------|
|Nuget|[Link](https://www.nuget.org/packages/MvvmCross/)|[Link](https://www.nuget.org/packages/FreshMvvm/)|[Link](https://www.nuget.org/packages/Prism.Forms/)|[Link](https://www.nuget.org/packages/MvvmLight/)|[Link](https://www.nuget.org/packages/Caliburn.Micro)|
|Nuget Last updated*|1 month ago|5 days ago|5 months ago|6 months ago|14 months ago|
|Downloads - last major version*|86,597|59,845|74,273|94,670|122,487|
|Downloads - total*|1,071,196|148,771|518,698|1,152,775|793,456|
|Downloads - average per day*|497|105|355|384|273|

 '* As of 21 March 2019

## Summary

**MVVMCross** is the most feature complete and suitable for most sizable applications.  It has a very large community support base from a contributions and troubleshooting point of view. The biggest drawback for me of MVVMCross as far as XAML goes, its that you need to use their MvxContentPage in your declarations.

The other drawback I've found with MVVMCross are the mysterious bugs that appear in Release Mode because you havne't included an up to date [LinkerPleaseInclude.cs](https://github.com/MvvmCross/MvvmCross-Samples/blob/master/StarWarsSample/StarWarsSample.Forms/StarWarsSample.Forms.iOS/LinkerPleaseInclude.cs) file which they provide in their sample applications.

**Prism** is suitable for large applications, but I find the documentation lacking.  My pet peev is use of magic strings for Navigation to a page.  The documentation lists most of the default containers as legacy, so only DryIOC is performant enough.  There is however and undocumented [Prism.SimpleInjector](https://www.nuget.org/packages/Prism.SimpleInjector/) nuget package which should also offer good performance as far as IOC containers go. 

The benefit that **MVVMCross** and **MVVMLight** have over the other "Xamarin Forms Only" frameworks is that you can have your Core ViewModels be rendered to Native and Forms platofrms (eg.  Xamarin Forms for iOS and Xamarin Native for tvOS).

With the exception of **FreshMVVM** which is a Xamarin Forms first class citizen, you get the feeling that all the others supported Xamarin Forms as an afterthought because they were convceived before Xamarin Forms took off.   **MVVMCross** seems to put more effort behind Xamarin Native but having use **MVVMCross** in a Xamarin Forms app, the support is very good too.

I think **MVVMCross** and **Prism** are great for enterprise applications because they guide you down a particular pattern.  So its easy for a bunch of developers to follow the familiar pattern when working on multiple projects in an organisation that use **MVVMCross** or **Prism** consitently.  

I think **FreshMVVM** is well thought out and easy to use, but what really puts me off completely is the prefix of everything with "Fresh"! 

**MVVMCross** and **MVVMLight** have very high average downloads per day, but their history goes way back before Xamarin Forms became popular.  So that would leave **Prism** as the highest downloads from a pure Xamarin Forms point of view.

**MVVMLight** and **Caliburn.Micro** only have one major contributor and suitable for light applications. Documenation is not that good or up to date.

Having used **Caliburn.Micro** in its hey dey with Windows Desktop and Windows Phone applications, it was quite revolutionary, with many people using it over MVVMLight because it had so many nifty features such as Auto Binding of Properties to visual elements if the element had the same name.  That feature seems to have dropped off in the Xamarin version, probably for technical reasons.  Caliburn.Micro's evolution seems to be the slowest which is sad given where its come from.


### So which one should you use?

The cop out answer is "it depends", but it really does. If you have used **MVVMCross**, **MVVMLight** for Xamarin Native applications before (or **Prism** for native *Windows* applications) and are now using Xamarin Forms, it makes sense to continue to use what you're used to.  

If you have *no* experience with any MVVM frameworks and you have a small app but want some of the nifty features of an MVVM framework, I would say **FreshMVVM** is a good choice. 

But if you really wanted my opinion, considering all of the above and despite my bias toward MVVMCross, I would order them like this:

1. MVVMCross
2. Prism.Forms (use DryIOC or SimpleInjector IOC container)
3. FreshMVVM
4. MVVMLight
5. Caliburn Micro

## Resources

### Framework Comparisons
- [Adam Pedley on Xamarin Help](https://xamarinhelp.com/use-xamarin-forms-mvvm-framework/)
- [Devlin Duldulao on Prism](https://devlinduldulao.pro/using-prism-framework-in-xamarin-forms/)

### IOC Container Performance Comparisons

- [Daniel Palme on GitHub](https://github.com/danielpalme/IocPerformance)
- [Adam Pedley on Xamarin Help](https://xamarinhelp.com/ioc-container-performance/)

### Official Documentation

- [MVVMCross](https://www.mvvmcross.com/documentation/)
- [FreshMVVM](https://github.com/rid00z/FreshMvvm)
- [Prism](http://prismlibrary.github.io/docs/)
- [MVVMLight](https://galasoft.ch/posts/2014/07/using-xamarin-forms-with-mvvmlight)
- [Caliburn.Micro](https://caliburnmicro.com/documentation/)

### Official Samples

- MVVMCross
  - [Playground](https://github.com/MvvmCross/MvvmCross/tree/develop/Projects/Playground)
  - [Samples](https://github.com/MvvmCross/MvvmCross-Samples)
- [FreshMVVM](https://github.com/rid00z/FreshMvvm/tree/master/samples)
- [Prism](https://github.com/PrismLibrary/Prism-Samples-Forms.git)
- [MVVMLight](https://github.com/lbugnion/sample-crossplatform-flowers.git)
- [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro/tree/master/samples)

