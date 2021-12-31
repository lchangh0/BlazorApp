// node.js를 사용해서 구현했다.
// 웹브라우저 프로그램을 실행한다.
// 웹서버를 실행해서 요청을 기다리고
// 요청이 들어오면 웹브라우저 프로그램을 종료시킨다.

var execFile = require('child_process').execFile;

// child process를 시작한다.
console.log('start child process');
var child = execFile('chrome',
['http://localhost:5000'],
function(error, stdout, stderr){
    console.log('child end');
} );

console.log('start listening...');

var http = require('http');

var app = http.createServer(function(request, response){
    var url = request.url;
    console.log('receive rquest, url=' + url );

    response.writeHead(200);
    response.end('welcome');

    // child process를 종료한다.
    console.log('kill child process')
    child.kill();

    // listening을 종료한다.
    console.log('close');
    app.close();
});

console.log('listening...');
// 비동기 방식으로 listen 시작
app.listen(8080);
