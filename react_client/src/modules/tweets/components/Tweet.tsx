import { FC } from "react"
import {Button, Card} from "react-bootstrap"
import { useDispatch } from "react-redux"
import { tweetsActions } from "../tweetsSlice"

export type TweetType = {
    id: string,
    createdAt: string,
    updatedAt: string,
    userId: string,
    userName: string,
    uniqueName: string,
    content: string,
    rootTweet?: TweetType,
    tweets?: TweetType[],
    likes: number
}

type TweetProps = {
    tweet: TweetType
}

export const Tweet : FC<TweetProps> = ({tweet}) => {
    const dispatch = useDispatch();

    const deleteTweet = (tweet: TweetType) => {
        dispatch(tweetsActions.deleteTweetAsync(tweet.id))
    }

    return(
        <Card style={{ width: '40rem' }}>
        <Card.Body>
            <Card.Title>{tweet.userName} @{tweet.uniqueName}</Card.Title>
            <Card.Text>
            {tweet.content}
            </Card.Text>
            <Button>Likes {tweet.likes}</Button>
            <Button onClick={() => deleteTweet(tweet)}>Delete</Button>
        </Card.Body>
        <Card.Footer className="text-muted">{tweet.createdAt}</Card.Footer>
    </Card>
    )
}