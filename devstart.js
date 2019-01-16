var exec = require('child_process').exec, child;
var state = "java -jar " + "c://test.jar "
var exec = require('child_process').exec;

var execSync = require('child_process').execSync;
execSync('npm install', { cwd: 'ingredient-checklist-app' });

var serverProcess = exec('dotnet watch run selfhosted', { cwd: 'IngredientChecklist/WebAPI' });

console.log('Api Server Running on Process: ' + serverProcess.pid);

serverProcess.stdout.pipe(process.stdout);
serverProcess.stderr.pipe(process.stderr);

// Listen if the process closed
serverProcess.on('close', function (exit_code) {
	console.log('Closed before stop: Closing code: ', exit_code);
});


var uiProcess = exec('ng serve -o --proxy-config proxy.config.json', { cwd: 'ingredient-checklist-app' });

console.log('UI Server Running on Process: ' + uiProcess.pid);

uiProcess.stdout.pipe(process.stdout);
uiProcess.stderr.pipe(process.stderr);


// Listen if the process closed
uiProcess.on('close', function (exit_code) {
	console.log('Closed before stop: Closing code: ', exit_code);
});


process.on('SIGINT', function () {

	console.log('killing');

	serverProcess.kill();

	uiProcess.kill();

});
