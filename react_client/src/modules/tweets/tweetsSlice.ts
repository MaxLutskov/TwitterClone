import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { TweetType } from './components/Tweet'

type TweetsState = {
  tweets: TweetType[]
}

const initialState: TweetsState= {
  tweets: [{
    id: "1", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet1", likes: 0,
  },
  {
    id: "2", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet2", likes: 0,

  },
  {
    id: "3", createdAt: "06.18.2023", updatedAt: "06.18.2003", userId: "0", userName: "Max", uniqueName: "zhmax", content: "Tweet3", likes: 0,

  }]
}

export const tweetsSlice = createSlice({
  name: 'tweets',
  initialState,
  reducers: {
    getAllTweetsAsync: (state, action: PayloadAction<{page: number, pageSize: number}>) => state,
    getAllTweets: (state, action: PayloadAction<TweetType[]>) => {
      state.tweets.push(...action.payload)
    },
    getTweetsByUserIdAsync: (state, action: PayloadAction<{userId: string, page: number, pageSize: number}>) => state,
    getTweetsByUserId: (state, action: PayloadAction<TweetType[]>) => {
      state.tweets.push(...action.payload)
    },
    getTweetByIdAsync: (state, action: PayloadAction<string>) => state,
    getTweetById: (state, action: PayloadAction<TweetType>) => {
      state.tweets.push(action.payload)
    },
    addTweetAsync: (state, action: PayloadAction<TweetType>) => state,
    updateTweetAsync: (state, action: PayloadAction<TweetType>) => state,
    deleteTweetAsync: (state, action: PayloadAction<string>) => state,
  },
})

export const tweetsActions = tweetsSlice.actions
export const tweetsReducer = tweetsSlice.reducer