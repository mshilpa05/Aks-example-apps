FROM python:3.6-alpine

COPY . /opt/

WORKDIR /opt/example-app

RUN pip install flask

RUN pip install requests

WORKDIR /opt

ENTRYPOINT ["python", "app.py"]