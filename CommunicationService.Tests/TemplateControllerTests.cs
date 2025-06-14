using CommunicationService.API.Controllers;
using CommunicationService.Application.DTOs;
using CommunicationService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class FakeTemplateService : ITemplateService
{
    public TemplateDto? LastCreated { get; private set; }

    public Task<TemplateDto> CreateAsync(TemplateDto template)
    {
        template.Id = Guid.NewGuid();
        LastCreated = template;
        return Task.FromResult(template);
    }

    // The following methods are not used in this test, so they throw NotImplementedException.
    public Task DeleteAsync(Guid id) => throw new NotImplementedException();
    public Task<IEnumerable<TemplateDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<TemplateDto?> GetByIdAsync(Guid id) => throw new NotImplementedException();
    public Task<TemplateDto> UpdateAsync(TemplateDto template) => throw new NotImplementedException();
}

public class TemplateControllerTests
{
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