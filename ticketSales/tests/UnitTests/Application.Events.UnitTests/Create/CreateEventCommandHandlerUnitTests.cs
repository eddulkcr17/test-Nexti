using Application.Events.Create;
using Domain.DomainErrors;
using Domain.Events;
using Domain.Primitives;


namespace Application.Events.UnitTests.Create;

public class CreateEventCommandHandlerUnitTests
{
    private readonly Mock<IEventRepository> _mockEventRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateEventCommandHandler _handler;

    public CreateEventCommandHandlerUnitTests()
    {
        _mockEventRepository = new Mock<IEventRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateEventCommandHandler(_mockEventRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async void HandleCreateEvent_WhenAddressHasBadFormat_ShouldReturnValidationError()
    {
        //Arrange
        //configuracion de parametros de entrada 
        CreateEventCommand command = new CreateEventCommand("3/14/2024","ecuador","amazonas","patria","quito","pichincha","1722",
                                        "eduardo","5.00","a");
        //Act
        //ejecucion de la prueba unitaria
        var result = await _handler.Handle(command,default);

        //Assert
        //verificacion de los datos 
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorOr.ErrorType.Validation);
        result.FirstError.Code.Should().Be(Errors.Events.AddressWithBadFormat.Code);
        result.FirstError.Description.Should().Be(Errors.Events.AddressWithBadFormat.Description);
}
}