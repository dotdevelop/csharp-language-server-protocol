using FluentAssertions;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using TestingUtils;
using Xunit;

namespace Lsp.Tests.Models
{
    public class FormattingOptionsTests
    {
        [Theory]
        [JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = new FormattingOptions {
                { "tabSize", 4 },
                { "insertSpaces", true },
                { "somethingElse", "cool" }
            };
            var result = Fixture.SerializeObject(model);

            result.Should().Be(expected);

            var deresult = new LspSerializer(ClientVersion.Lsp3).DeserializeObject<FormattingOptions>(expected);
            deresult.Should().BeEquivalentTo(model, x => x.UsingStructuralRecordEquality());
        }

        [Fact]
        public void Should_Not_Require_A_Value_To_Be_Defined()
        {
            var model = new FormattingOptions();
            model.InsertSpaces.Should().BeFalse();
            model.TabSize.Should().Be(-1);
            model.InsertFinalNewline.Should().BeFalse();
            model.TrimFinalNewlines.Should().BeFalse();
            model.TrimTrailingWhitespace.Should().BeFalse();
        }

        [Fact]
        public void Should_Allow_Values_To_Be_Set()
        {
            var model = new FormattingOptions();
            model.InsertSpaces = true;
            model.TabSize = 4;
            model.InsertFinalNewline = true;
            model.TrimFinalNewlines = true;
            model.TrimTrailingWhitespace = true;
        }
    }
}
