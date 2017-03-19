#!/usr/bin/python
# -*- coding: utf-8 -*-


class Actor:
    def __init__(self, uid, name):
        self.uid = uid
        self.name = name
        self.conversations = {}

    def get_conversation(self, quest_id, quest_status):
        return self.conversations[quest_id].get_conversation_phrase(quest_status)


class Conversation:
    def __init__(self, uid, quest_id, not_available_cs, completed_cs, active_cs, available_cs):
        self.uid = uid
        self.quest_id = quest_id
        self.not_available_cs = not_available_cs
        self.completed_cs = completed_cs
        self.active_cs = active_cs
        self.available_cs = available_cs

    def get_conversation_phrase(self, quest_status):
        if quest_status == ConversationStatus.QUEST_NOT_AVAILABLE:
            return self.not_available_cs.get_message()
        elif quest_status == ConversationStatus.QUEST_STATUS_COMPLETED:
            return self.completed_cs.get_message()
        elif quest_status == ConversationStatus.QUEST_STATUS_ACTIVE:
            return self.active_cs.get_message()
        elif quest_status == ConversationStatus.QUEST_STATUS_AVAILABLE:
            return self.available_cs.get_message()


class ConversationStatus:
    QUEST_NOT_AVAILABLE = 0
    QUEST_STATUS_COMPLETED = 1
    QUEST_STATUS_AVAILABLE = 2
    QUEST_STATUS_ACTIVE = 3

    def __init__(self, uid, quest_status, messages):
        self.uid = uid
        self.quest_status = quest_status
        self.messages = messages
        self.count = 0


    def get_message(self):
        phrase = self.messages[0]
        if len(self.messages) > self.count + 1:
            self.count += 1

        return phrase



