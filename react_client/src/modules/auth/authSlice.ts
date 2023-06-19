import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { TweetType } from '../tweets/components/Tweet'
import { access } from 'fs'

type AuthState = {
  userId: string,
  token: string
}

export type LoginInput = {
    email: string,
    password: string
}

export type RegisterInput = {
    email: string,
    password: string,
    userName: string
}


const initialState: AuthState= {
    userId: "",
    token: ""
}

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        loginAsync: (state, action: PayloadAction<LoginInput>) => state,
        setAuthedUser: (state, action: PayloadAction<{generatedToken: string, id: string}>) => {
            console.log(action.payload.generatedToken)
            state.token = action.payload.generatedToken
            state.userId = action.payload.id
        },
        registerAsync: (state, action: PayloadAction<RegisterInput>) => state,
        register: (state) => state,
        logout: (state) => {
            state.token = ""
            state.userId = ""
        }
    },
})

export const authActions = authSlice.actions
export const authReducer = authSlice.reducer