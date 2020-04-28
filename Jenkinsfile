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
      step ([$class: 'MSTestPublisher', testResultsFile:"**/TestResults/UnitTests.trx", failOnError: true, keepLongStdio: true])
    }
  }  

 
  environment {
    ASPNETCORE_ENVIRONMENT = 'Production'
  }
}