using FluentAssertions;
using Infrastructure.Services.Externals;
using Microsoft.Extensions.Options;
using Moq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestLibrary.Services.Externals;

public class EmailServiceTests
{
    private readonly Mock<IOptions<EmailSettings>> _optionsMock;
    private readonly EmailSettings _emailSettings;
    private readonly EmailService _sut; // System Under Test

    public EmailServiceTests()
    {
        _emailSettings = new EmailSettings
        {
            SmtpHost = "smtp.example.com",
            SmtpPort = 587,
            From = "test@example.com",
            AppPassword = "securepassword123"
        };

        _optionsMock = new Mock<IOptions<EmailSettings>>();
        _optionsMock.Setup(x => x.Value).Returns(_emailSettings);

        _sut = new EmailService(_optionsMock.Object);
    }

    [Fact]
    public void Constructor_Should_Initialize_With_Correct_Settings()
    {
        // Arrange & Act
        var service = new EmailService(_optionsMock.Object);

        // Assert
        service.Should().NotBeNull();
    }

    [Fact]
    public async Task SendAsync_Should_NotThrow_ArgumentException_With_Valid_Parameters()
    {
        // Arrange
        var recipientEmail = "recipient@example.com";
        var subject = "Test Subject";
        var content = "<h1>Test Content</h1>";
        var cancellationToken = CancellationToken.None;

        // Act & Assert
        // نکته: این تست سعی به اتصال به SMTP دارد. در محیط تست واقعی باید از SMTP فیک استفاده کرد.
        // اگر SMTP در دسترس نباشد، خطای شبکه می‌دهد که طبیعی است.
        // هدف این تست بررسی صحت پارامترها و عدم پرتاب ArgumentException است.
        var act = () => _sut.SendAsync(recipientEmail, subject, content, cancellationToken);

        // انتظار داریم خطای ArgumentException ندهد
        await act.Should().NotThrowAsync<ArgumentException>();
    }

    [Theory]
    [InlineData("user@domain.com", "Subject Test", "Content Test")]
    [InlineData("another@test.ir", "سلام", "محتوای فارسی")]
    [InlineData("test@email.org", "Test با ایموجی 😊", "محتوای تست")]
    public async Task SendAsync_Should_Accept_Valid_Emails_And_Subjects(string email, string subject, string content)
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        // Act & Assert
        var act = () => _sut.SendAsync(email, subject, content, cancellationToken);

        // نباید خطای اعتبارسنجی آرگومان بدهد
        await act.Should().NotThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task SendAsync_Should_Throw_Exception_When_Email_Is_NullOrEmpty()
    {
        // Arrange
        var subject = "Test Subject";
        var content = "Test Content";
        var cancellationToken = CancellationToken.None;

        // Act & Assert
        await _sut.Invoking(s => s.SendAsync("", subject, content, cancellationToken))
            .Should().ThrowAsync<ArgumentException>()
            .WithMessage("*email*");

        await _sut.Invoking(s => s.SendAsync(null!, subject, content, cancellationToken))
            .Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task SendAsync_Should_Throw_Exception_When_Subject_Is_NullOrEmpty()
    {
        // Arrange
        var email = "test@example.com";
        var content = "Test Content";
        var cancellationToken = CancellationToken.None;

        // Act & Assert
        await _sut.Invoking(s => s.SendAsync(email, "", content, cancellationToken))
            .Should().ThrowAsync<ArgumentException>()
            .WithMessage("*subject*");
    }

    [Fact]
    public async Task SendAsync_Should_Throw_Exception_When_Content_Is_NullOrEmpty()
    {
        // Arrange
        var email = "test@example.com";
        var subject = "Test Subject";
        var cancellationToken = CancellationToken.None;

        // Act & Assert
        await _sut.Invoking(s => s.SendAsync(email, subject, "", cancellationToken))
            .Should().ThrowAsync<ArgumentException>()
            .WithMessage("*content*");
    }
}
