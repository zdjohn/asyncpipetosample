# Async Await in akka.net ReceiveAsync v.s. PipeTo
use case compare between akka.net PipeTo and ReceiveAsync

this is a sample code for https://medium.com/zdjohn/multi-threading-in-akka-net-async-v-s-pipeto-60967f0b312a

in this reapo contains 3 different branches, which are 3 different approches to make async await calls in akka

in branch `master`:  is standard "PipeTo" aproach

in branch `semaphore`: i showed how to use semaphore to control the threads in parallel

in branch `receive-async`: i used RoundRoubin router + Receive Async to control message throughput, which also enabled up contorling the threads parallelism from a actors modle fashion



