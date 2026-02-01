

using Grpc.Core;
using Hospital;

public class AppointmentServiceImpl 
    : AppointmentService.AppointmentServiceBase
{
    public override Task<PatientReply> GreetPatient(
        PatientRequest request,
        ServerCallContext context)
    {
        return Task.FromResult(new PatientReply
        {
            Message = $"Welcome {request.PatientName}, your appointment is confirmed."
        });
    }
}
