import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { TweetType } from '../../components/Tweet'

type TweetsState = {
  tweets: TweetType[]
}

const initialState: TweetsState= {
  tweets: [{
    id: "1", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet1", likes: 0,
    rootTweet: null,
    tweets: null
  },
  {
    id: "2", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet2", likes: 0,
    rootTweet: null,
    tweets: null
  },
  {
    id: "3", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet3", likes: 0,
    rootTweet: null,
    tweets: null
  }]
}

export const tweetsSlice = createSlice({
  name: 'tweets',
  initialState,
  reducers: {
    getTweets: (state, action: PayloadAction<TweetType[]>) => {
        state.tweets.push(...action.payload)
      },
    addTweet: (state, action: PayloadAction<TweetType>) => {
      state.tweets.push(action.payload)
    },
    deleteTweet: (state, action: PayloadAction<TweetType>) => {
      state.tweets = state.tweets.filter(t => t.id !== action.payload.id)
    },
  },
})

export const tweetsActions = tweetsSlice.actions
export const tweetsReducer = tweetsSlice.reducer