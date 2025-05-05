pipeline {
    agent any
 
    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/DivyanshuDilip/ParallelTestingWithCSharp.git', branch: 'ParallelTesting'
            }
        }
 
        stage('Restore') {
            steps {
                dir('RestSharpProject') {
                    sh 'dotnet restore'
                }
            }
        }
 
        stage('Build') {
            steps {
                dir('RestSharpProject') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }
 
        stage('Test') {
            steps {
                dir('RestSharpProject') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }
 
        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format not supported by junit step. Convert to XML if needed.'
            }
        }
    }
}