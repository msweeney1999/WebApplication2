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
    stage('Package') {
        steps {
            sh 'cd WebApplication2'
            sh 'dotnet package'
        }
    }
    stage('Deploy') {
      steps {
        //sh 'rm -rf /var/www/core-app'
        //sh 'cp -R . /var/www/core-app'
      }
    }
  }
  post {
    always {
      //step ([$class: 'MSTestPublisher', testResultsFile:"**/TestResults/UnitTests.trx", failOnError: true, keepLongStdio: true])
    }
  }
  tools {
    //msbuild '.NET Core 2.2.103'
  }
  environment {
    ASPNETCORE_ENVIRONMENT = 'Production'
  }
}