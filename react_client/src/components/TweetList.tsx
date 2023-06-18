import { FC } from "react"
import { Stack } from "react-bootstrap"
import { Tweet, TweetType } from "./Tweet"

type TweetListProps = {
    tweets: TweetType[]
}

export const TweetList : FC<TweetListProps> = ({tweets}) => {
    return(
        <Stack gap={3} className="align-items-center">
            {
            tweets.map(tweet => 
            <Tweet tweet={tweet} key={tweet.id}/>
            )
            }
        </Stack>  
    )
}