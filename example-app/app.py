from flask import Flask, jsonify, render_template
import os
import requests

app = Flask(__name__)

@app.route("/")
def main():
    # node_name = os.environ.get('NODE_NAME')
    pod_name = os.environ.get('POD_NAME')
    # pod_namespace = os.environ.get('POD_NAMESPACE')

    api_url = os.environ.get('API_URL')
    # api_url = "https://localhost:7151/api/hello"
    # api_url = "https://host.docker.internal:7151/api/hello"

    print(api_url)
  
    response = requests.get(api_url, verify=False)

    try:

        if response.status_code == 200:
            data = response.text
            
        else:
            data = "Failed to fetch"
    except Exception as ex:
        print(ex)

    # return render_template('pod_details.html', node_name=node_name, pod_name=pod_name, pod_namespace=pod_namespace, message_from_other_pod = data)
    return render_template('pod_details.html', pod_name=pod_name,  message_from_other_pod=data)

if __name__ == "__main__":

    app.run(host="0.0.0.0", port=8085)
