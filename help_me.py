import sys
from typing import List
from urllib.error import HTTPError
from dotenv import dotenv_values
import requests

APIKEY: str = dotenv_values("./.env").get("APIKEY", None)
APIURL: str = "https://api.openai.com/v1/completions"


def ask_chat(question: str) -> List[str]:
    """Contacts ChatGPT with the provided question and returns an answer

    Args:
        question (str): thy's query

    Returns:
        List[str]: the answer list gotten from the space wizard
    """

    chat_req_headers = {"Authorization": f"Bearer {APIKEY}"}

    chat_req_body = {
        "model": "text-davinci-003",
        "prompt": question,
        "temperature": 1,
        "max_tokens": 100,
    }
    try:

        request = requests.post(APIURL, headers=chat_req_headers, json=chat_req_body)
        request.raise_for_status()

        res = request.json()
        return res.get("choices", None)
    except HTTPError as ex:
        print("something went wrong contacting the space wizard. . .", ex, end="\n")
        #  don't return just goooOooOo.
        #  is this bad design ? ? ?
        sys.exit(1)


def extract_answer(answeres: List[str]) -> str:
    if answeres is None:
        return "No answers provided"

    return answeres[0].get("text", "there were no answeres")


def main(question: str) -> None:
    print(extract_answer(ask_chat(question)))


if __name__ == "__main__":
    if len(sys.argv) == 1 or sys.argv[1] == " ":
        print("Usage: help-me <Query>")
        sys.exit(1)
    main(sys.argv[1])
