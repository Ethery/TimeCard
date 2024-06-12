pipeline {
	agent {
		node {
			label 'Unity'
		}
	}
	stages { 
		stage('Create archive') {
			steps {
				sh '''cd ${WORKSPACE_TMP}
				zip -r ${WORKSPACE}/${BUILD_TAG}_APP.zip Game'''
			}
		}
	}
    post {
        always {
            archiveArtifacts artifacts: '*_APP.zip', fingerprint: true, onlyIfSuccessful: true
        }
    }
}