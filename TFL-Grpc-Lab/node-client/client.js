const grpc = require('@grpc/grpc-js');
const protoLoader = require('@grpc/proto-loader');
const path = require('path');

/* STEP 1: Load proto file */
const packageDef = protoLoader.loadSync(
  path.join(__dirname, 'protos/appointment.proto')
);

/* STEP 2: Convert proto to JS object */
const grpcObj = grpc.loadPackageDefinition(packageDef);

/* STEP 3: Access hospital package */
const hospital = grpcObj.hospital;

/* STEP 4: Create client (REMOTE object) */
const client = new hospital.AppointmentService(
  'localhost:5056',
  grpc.credentials.createInsecure()
);

/* STEP 5: Call remote method */
client.GreetPatient({ patientName: 'Amit' }, (err, response) => {
  if (err) {
    console.error(err);
    return;
  }
  console.log(response.message);
});
