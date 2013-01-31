HtmlSpikeCreator
================

A simple spike to allow some fast html generation in C#



##Examples

###Hello world
```C#
private dynamic _ = HtmlFactory.CreateHtmlFactory();
var html=_.html().ToString();
//html is "<html></html>"
```

###Tags with content
```C#
_.html(
    _.head(_.title("Sweet stuff")),
    _.body(
        _.h1("Hello world!"))).ToString();
```

###Tags with attributes
```C#
_.html(
    _.body(@class: "myClass"),
    lang: "en")
```

More to come!
