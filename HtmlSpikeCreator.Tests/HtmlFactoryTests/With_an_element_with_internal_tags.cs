using NUnit.Framework;

namespace HtmlSpikeCreator.Tests.HtmlFactoryTests
{
    public class With_an_element_with_internal_tags
    {
        private dynamic _ = HtmlFactory.CreateHtmlFactory();
        [Test]
        public void It_should_return_an_html_string_with_the_document()
        {
            var html =
                _.html(
                    _.head(_.title("Sweet stuff")),
                    _.body(
                        _.h1("Hello world!"))).ToString();
            const string expected = "<html><head><title>Sweet stuff</title></head>" +
                                    "<body><h1>Hello world!</h1></body></html>";
            Assert.AreEqual(expected, html);
        }
    }
}