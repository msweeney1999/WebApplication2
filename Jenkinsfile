pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git 'https://github.com/msweeney1999/WebApplication2.git'
      }
    }
    stage('Restore') {
      steps {
        sh 'dotnet restore'
      }
    }
    stage('Build') {
      steps {
        
        sh 'dotnet build'
      }
    }
    stage('Test') {
      steps {
        sh 'dotnet test --logger "trx;LogFileName=UnitTests.trx"'
      }
    }
    stage('Publish') {
        steps {
            sh 'cd WebApplication2'
            sh 'dotnet publish -r linux-x64 -c Release'
        }
    }
  
  }
  post {
    always {
      steps {
        ([$class: 'MSTestPublisher', testResultsFile:"**/TestResults/UnitTests.trx", failOnError: true, keepLongStdio: true])
      
      script: emailext ( 
          to: "mark.sweeney@nttdata.com",
          subject: "STARTED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
          body: """<p>STARTED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]':</p>
                  <p>Check console output at &QUOT;<a href='${env.BUILD_URL}'>${env.JOB_NAME} [${env.BUILD_NUMBER}]</a>&QUOT;</p>""")
    }
  } 
  } 

 
  environment {
    ASPNETCORE_ENVIRONMENT = 'Production'
  }
}