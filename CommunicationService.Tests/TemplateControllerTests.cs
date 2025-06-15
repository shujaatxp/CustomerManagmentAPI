using CommunicationService.API.Controllers;
using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

/// <summary> Syed Shujaat Ali
/// Fake implementation of <see cref="ITemplateService"/> for unit testing.
/// </summary>
public class FakeTemplateService : ITemplateService
{
    /// <summary> Syed Shujaat Ali
    /// Gets the last created template.
    /// </summary>
    public TemplateDto? LastCreated { get; private set; }

    /// <summary> Syed Shujaat Ali
    /// Simulates creating a new template.
    /// </summary>
    /// <param name="template">The template data transfer object.</param>
    /// <returns>The created <see cref="TemplateDto"/> with a generated Id.</returns>
    public Task<TemplateDto> CreateAsync(TemplateDto template)
    {
        template.Id = Guid.NewGuid();
        LastCreated = template;
        return Task.FromResult(template);
    }

    // The following methods are not used in this test, so they throw NotImplementedException.

    /// <inheritdoc/>
    public Task DeleteAsync(Guid id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<IEnumerable<TemplateDto>> GetAllAsync() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<TemplateDto?> GetByIdAsync(Guid id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<TemplateDto> UpdateAsync(TemplateDto template) => throw new NotImplementedException();
}

/// <summary> Syed Shujaat Ali
/// Unit tests for <see cref="TemplateController"/>.
/// </summary>
public class TemplateControllerTests
{
    /// <summary> Syed Shujaat Ali
    /// Tests that the Create action returns a CreatedAtActionResult with the created template.
    /// </summary>
    [Fact]
    public async Task Create_ReturnsCreatedAtActionResult_WithCreatedTemplate()
    {
        // Arrange
        var fakeService = new FakeTemplateService();
        var inputDto = new TemplateDto
        {
            Name = "Test",
            Subject = "Subject",
            Body = "Body"
        };
        var controller = new TemplateController(fakeService);

        // Act
        var result = await controller.Create(inputDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<TemplateDto>(createdResult.Value);
        Assert.Equal(inputDto.Name, returnValue.Name);
        Assert.Equal(inputDto.Subject, returnValue.Subject);
        Assert.Equal(inputDto.Body, returnValue.Body);
        Assert.NotEqual(Guid.Empty, returnValue.Id);
    }
}